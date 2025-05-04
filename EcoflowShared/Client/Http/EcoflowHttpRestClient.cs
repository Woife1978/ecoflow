using System.Text;
using EcoflowShared.exceptions;

namespace EcoflowShared.http
{
    public class HttpRestClient
    {
        private const string DEFAULT_BASE_URL = "https://api-e.ecoflow.com";

        private readonly string _baseUrl;
        private readonly string _accessToken;
        private readonly string _secretToken;
        private readonly HttpClient _httpClient;

        public HttpRestClient(string baseUrl, string accessToken, string secretToken, HttpClient httpClient)
        {
            _baseUrl = baseUrl;
            _accessToken = accessToken;
            _secretToken = secretToken;
            _httpClient = httpClient;
        }

        public HttpRestClient(string baseUrl, string accessToken, string secretToken, HttpClientHandler httpClientHandler)
        {
            _baseUrl = baseUrl;
            _accessToken = accessToken;
            _secretToken = secretToken;
            _httpClient = new HttpClient(httpClientHandler);
        }

        public HttpRestClient(string baseUrl, string accessToken, string secretToken)
        {
            _baseUrl = baseUrl;
            _accessToken = accessToken;
            _secretToken = secretToken;
            _httpClient = new HttpClient();
        }

        public HttpRestClient(string accessToken, string secretToken)
            : this(DEFAULT_BASE_URL, accessToken, secretToken, new HttpClient())
        {
        }

        public HttpResponseMessage Get(string url, QueryString query)
        {
            return PrepareAndSendRequest(url, query, HttpMethod.Get);
        }

        public async Task<HttpResponseMessage> GetAsync(string url, QueryString query)
        {
            return await PrepareAndSendRequestAsync(url, query, HttpMethod.Get);
        }

        public async Task<HttpResponseMessage> PostAsync(string url, QueryString query)
        {
            return await PrepareAndSendRequestAsync(url, query, HttpMethod.Post);
        }

        public async Task<HttpResponseMessage> PutAsync(string url, QueryString query)
        {
            return await PrepareAndSendRequestAsync(url, query, HttpMethod.Put);
        }

        public async Task<HttpResponseMessage> DeleteAsync(string url, QueryString query)
        {
            return await PrepareAndSendRequestAsync(url, query, HttpMethod.Delete);
        }

        private HttpRequestMessage PrepareRequest(string url, QueryString queryParams, HttpMethod method)
        {
            if ((method == HttpMethod.Post || method == HttpMethod.Put) && queryParams == null)
            {
                throw new EcoflowInvalidParameterException("Body request for POST and PUT requests are mandatory");
            }

            string fullUrl = queryParams == null || queryParams.IsEmpty()
                ? $"{_baseUrl}{url}"
                : $"{_baseUrl}{url}?{queryParams.ToQueryString()}";

            AuthHeaders authHeaders = queryParams == null
                ? new AuthHeaders(_accessToken, _secretToken)
                : new AuthHeaders(queryParams, _accessToken, _secretToken);

            var request = new HttpRequestMessage(method, fullUrl);

            if (method == HttpMethod.Post || method == HttpMethod.Put)
            {
                request.Content = new StringContent(queryParams.ToString(), Encoding.UTF8, "application/json");
            }

            request.Headers.Add("accessKey", authHeaders.AccessKey);
            request.Headers.Add("nonce", authHeaders.Nonce);
            request.Headers.Add("timestamp", authHeaders.Timestamp);
            request.Headers.Add("sign", authHeaders.Sign);

            return request;
        }

        private async Task<HttpResponseMessage> PrepareAndSendRequestAsync(string url, QueryString query, HttpMethod method)
        {
            var request = PrepareRequest(url, query, method);
            return await SendRequestAsync(request);
        }

        private HttpResponseMessage PrepareAndSendRequest(string url, QueryString query, HttpMethod method)
        {
            var request = PrepareRequest(url, query, method);
            return SendRequest(request);
        }

        private async Task<HttpResponseMessage> SendRequestAsync(HttpRequestMessage request)
        {
            try
            {
                return await _httpClient.SendAsync(request);
            }
            catch (Exception ex)
            {
                throw new EcoflowHttpException(ex);
            }
        }

        private HttpResponseMessage SendRequest(HttpRequestMessage request)
        {
            try
            {
                return _httpClient.Send(request);
            }
            catch (Exception ex)
            {
                throw new EcoflowHttpException(ex);
            }
        }
    }
}