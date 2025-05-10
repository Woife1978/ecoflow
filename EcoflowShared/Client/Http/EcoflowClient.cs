
using EcoflowShared.exceptions;
using EcoflowShared.helpers.json;
using EcoflowShared.http.response;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace EcoflowShared.http
{
    public class EcoflowClient
    {
        private const string DEVICE_LIST_URL = "/iot-open/sign/device/list";
        private const string GET_QUOTA_URL = "/iot-open/sign/device/quota";
        private const string GET_ALL_QUOTA_URL = "/iot-open/sign/device/quota/all";

        public readonly HttpRestClient _restClient;
        private readonly RestApiResponseParser _responseParser;

        public EcoflowClient(HttpRestClient restClient, RestApiResponseParser responseParser)
        {
            _restClient = restClient;
            _responseParser = responseParser;
        }

        public EcoflowClient(HttpRestClient restClient)
        {
            _restClient = restClient;
            _responseParser = new RestApiResponseParser();
        }

        public List<EcoflowDevice> GetDevices()
        {
            HttpResponseMessage response = _restClient.Get(DEVICE_LIST_URL, new QueryString(new JObject()));
            if (!response.IsSuccessStatusCode)
            {
                throw new EcoflowHttpException(response.Content.ReadAsStringAsync().Result);
            }
            string responseBody = response.Content.ReadAsStringAsync().Result;
            return _responseParser.ParseDevicesResponse(responseBody).Data;
        }

        public async Task<Dictionary<string, object>> GetDeviceAllParametersAsync(string sn)
        {
            var queryParams = new JObject
            {
                { "sn", sn }
            };

            HttpResponseMessage response = await _restClient.GetAsync(GET_ALL_QUOTA_URL, new QueryString(queryParams));
            if (!response.IsSuccessStatusCode)
            {
                throw new EcoflowHttpException(response.Content.ReadAsStringAsync().Result);
            }
            string responseBody = response.Content.ReadAsStringAsync().Result;
            return _responseParser.ParseParamsResponse(responseBody).Data;
        }

        public Dictionary<string, object> GetDeviceAllParameters(string sn)
        {
            var queryParams = new JObject
            {
                { "sn", sn }
            };

            HttpResponseMessage response = _restClient.Get(GET_ALL_QUOTA_URL, new QueryString(queryParams));
            if (!response.IsSuccessStatusCode)
            {
                throw new EcoflowHttpException(response.Content.ReadAsStringAsync().Result);
            }
            string responseBody = response.Content.ReadAsStringAsync().Result;
            return _responseParser.ParseParamsResponse(responseBody).Data;
        }

        public T GetDeviceAllParameters<T>(string sn)
        {
            var queryParams = new JObject
            {
                { "sn", sn }
            };

            HttpResponseMessage response = _restClient.Get(GET_ALL_QUOTA_URL, new QueryString(queryParams));
            if (!response.IsSuccessStatusCode)
            {
                throw new EcoflowHttpException(response.Content.ReadAsStringAsync().Result);
            }
            string responseBody = response.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<T>(responseBody);
        }

        public async Task<Dictionary<string, object>> GetDeviceParameters(string sn, List<string> parameters)
        {
            var quotas = new JArray(parameters);
            var paramsObject = new JObject
            {
                { "quotas", quotas }
            };

            var requestParams = new JObject
            {
                { "sn", sn },
                { "params", paramsObject }
            };

            HttpResponseMessage response = await _restClient.PostAsync(GET_QUOTA_URL, new QueryString(requestParams));
            if (!response.IsSuccessStatusCode)
            {
                throw new EcoflowHttpException(response.Content.ReadAsStringAsync().Result);
            }
            string responseBody = response.Content.ReadAsStringAsync().Result;
            return _responseParser.ParseParamsResponse(responseBody).Data;
        }
    }
}