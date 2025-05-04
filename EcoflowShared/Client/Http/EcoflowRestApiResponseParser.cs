using Newtonsoft.Json;
using EcoflowShared.http.response;
using EcoflowShared.exceptions;


namespace EcoflowShared.http
{
    public class RestApiResponseParser
    {
        private static readonly JsonSerializerSettings JsonSerializerSettings = new JsonSerializerSettings
        {
            MissingMemberHandling = MissingMemberHandling.Ignore
        };

        public EcoflowApiResponse<T> ParseResponse<T>(string json)
        {
            try
            {
                return JsonConvert.DeserializeObject<EcoflowApiResponse<T>>(json, JsonSerializerSettings);
            }
            catch (JsonException ex)
            {
                throw new EcoflowResponseParserException(ex);
            }
        }

        public EcoflowApiResponse<List<EcoflowDevice>> ParseDevicesResponse(string json)
        {
            return ParseResponse<List<EcoflowDevice>>(json);
        }

        public EcoflowApiResponse<Dictionary<string, object>> ParseParamsResponse(string json)
        {
            return ParseResponse<Dictionary<string, object>>(json);
        }
    }
}