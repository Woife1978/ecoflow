using Newtonsoft.Json.Linq;
using EcoflowShared.exceptions;

namespace EcoflowShared.http
{
    public class QueryString
    {
        private readonly JObject _request;
        private string _queryString;
        private readonly object _lock = new object();

        public QueryString(JObject request)
        {
            _request = request;
        }

        public QueryString(Dictionary<string, object> jsonAsMap)
        {
            _request = JObject.FromObject(jsonAsMap);
        }

        public QueryString(string json)
        {
            _request = JObject.Parse(json);
        }

        public bool IsEmpty()
        {
            return _request == null || !_request.HasValues;
        }

        public string ToQueryString()
        {
            if (_queryString == null)
            {
                lock (_lock) // Thread-safety
                {
                    if (_queryString == null)
                    {
                        _queryString = CalculateQueryString();
                    }
                }
            }
            return _queryString;
        }

        private string CalculateQueryString()
        {
            var query = RequestToMap(_request);
            if (!query.Any())
            {
                return string.Empty;
            }

            return string.Join("&", query.Select(kvp => $"{kvp.Key}={kvp.Value}"));
        }

        private SortedDictionary<string, object> RequestToMap(JObject jsonObject)
        {
            if (jsonObject == null || !jsonObject.HasValues)
            {
                throw new EcoflowInvalidParameterException("parameters are empty");
            }

            var map = new SortedDictionary<string, object>();
            foreach (var property in jsonObject.Properties())
            {
                map = new SortedDictionary<string, object>(map.Concat(GetByObject(property.Name, property.Value)).ToDictionary(k => k.Key, v => v.Value));
            }
            return new SortedDictionary<string, object>(map);
        }

        private Dictionary<string, object> GetByObject(string key, JToken value)
        {
            if (string.IsNullOrEmpty(key) || value == null)
            {
                throw new EcoflowInvalidParameterException("parameters are empty");
            }

            if (value is JArray array)
            {
                return GetByJsonArray(key, array);
            }
            else if (value is JObject obj)
            {
                return GetByJsonObject(key, obj);
            }
            else
            {
                return new Dictionary<string, object> { { key, value.ToString() } };
            }
        }

        private Dictionary<string, object> GetByJsonArray(string key, JArray array)
        {
            if (string.IsNullOrEmpty(key) || array == null || !array.HasValues)
            {
                throw new EcoflowInvalidParameterException("either key or value is null or empty in the json array");
            }

            var map = new Dictionary<string, object>();
            for (int i = 0; i < array.Count; i++)
            {
                map = map.Concat(GetByObject(GetArrayKey(key, i), array[i])).ToDictionary(k => k.Key, v => v.Value);
            }
            return map;
        }

        private Dictionary<string, object> GetByJsonObject(string key, JObject obj)
        {
            if (string.IsNullOrEmpty(key) || obj == null || !obj.HasValues)
            {
                throw new EcoflowInvalidParameterException("either key or value is null or empty in the json object");
            }

            var map = new Dictionary<string, object>();
            foreach (var property in obj.Properties())
            {
                map = map.Concat(GetByObject(GetObjectKey(key, property.Name), property.Value)).ToDictionary(k => k.Key, v => v.Value);
            }
            return map;
        }

        private string GetObjectKey(string key, string innerKey)
        {
            return $"{key}.{innerKey}";
        }

        private string GetArrayKey(string key, int index)
        {
            return $"{key}[{index}]";
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType()) return false;

            var that = (QueryString)obj;
            return Equals(_request, that._request);
        }

        public override int GetHashCode()
        {
            return _request?.GetHashCode() ?? 0;
        }

        public override string ToString()
        {
            return ToQueryString();
        }
    }
}