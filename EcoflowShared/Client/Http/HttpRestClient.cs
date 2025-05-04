using System.Net.Http;
using System.Threading.Tasks;

namespace EcoflowShared.http
{
    public interface IHttpRestClient
    {
        Task<HttpResponseMessage> GetAsync(string url, QueryString queryParams);

        Task<HttpResponseMessage> PostAsync(string url, QueryString queryParams);

        Task<HttpResponseMessage> PutAsync(string url, QueryString queryParams);

        Task<HttpResponseMessage> DeleteAsync(string url, QueryString queryParams);

        Task<HttpResponseMessage> GetAsync(string url)
        {
            return GetAsync(url, null);
        }
    }
}