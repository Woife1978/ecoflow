using EcoflowShared.encryption;
using EcoflowShared.exceptions;

namespace EcoflowShared.http
{
    public class AuthHeaders
    {
        public QueryString QueryString { get; }
        public string AccessKey { get; }
        public string Nonce { get; }
        public string Timestamp { get; }
        public string Sign { get; }

        public AuthHeaders(QueryString queryString, string accessKey, string secretKey, string nonce, string timestamp)
        {
            QueryString = queryString;
            AccessKey = accessKey;
            Nonce = nonce;
            Timestamp = timestamp;
            Sign = SignWithSecretKey(secretKey);
        }

        public AuthHeaders(QueryString queryString, string accessKey, string secretKey)
        {
            QueryString = queryString;
            AccessKey = accessKey;
            Nonce = GenerateNonce();
            Timestamp = GenerateTimestamp();
            Sign = SignWithSecretKey(secretKey);
        }

        public AuthHeaders(string accessKey, string secretKey)
        {
            QueryString = null;
            AccessKey = accessKey;
            Nonce = GenerateNonce();
            Timestamp = GenerateTimestamp();
            Sign = SignWithSecretKey(secretKey);
        }

        private string SignWithSecretKey(string secretKey)
        {
            if (string.IsNullOrEmpty(secretKey))
            {
                throw new EcoflowInvalidParameterException("secretKey cannot be null or empty");
            }

            string keyValueString = GetKeyValueString();
            return new EncryptionService().EncryptHmacSHA256(keyValueString, secretKey);
        }

        private string GenerateNonce()
        {
            Random random = new Random();
            return random.Next(10000, 1000000).ToString();
        }

        private string GenerateTimestamp()
        {
            return DateTimeOffset.UtcNow.ToUnixTimeMilliseconds().ToString();
        }

        private string GetKeyValueString()
        {
            if (QueryString == null || QueryString.IsEmpty())
            {
                return $"accessKey={AccessKey}&nonce={Nonce}&timestamp={Timestamp}";
            }

            return $"{QueryString.ToQueryString()}&accessKey={AccessKey}&nonce={Nonce}&timestamp={Timestamp}";
        }

        public string[] ToHeadersArray()
        {
            var headers = new Dictionary<string, string>
            {
                { "accessKey", AccessKey },
                { "nonce", Nonce },
                { "timestamp", Timestamp },
                { "sign", Sign }
            };

            return headers.SelectMany(entry => new[] { entry.Key, entry.Value }).ToArray();
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType()) return false;

            var that = (AuthHeaders)obj;
            return Equals(QueryString, that.QueryString) &&
                   Equals(AccessKey, that.AccessKey) &&
                   Equals(Nonce, that.Nonce) &&
                   Equals(Timestamp, that.Timestamp);
        }

        public override int GetHashCode()
        {
            int result = QueryString?.GetHashCode() ?? 0;
            result = 31 * result + (AccessKey?.GetHashCode() ?? 0);
            result = 31 * result + (Nonce?.GetHashCode() ?? 0);
            result = 31 * result + (Timestamp?.GetHashCode() ?? 0);
            return result;
        }

        public override string ToString()
        {
            return $"RequestParameters{{queryString='{QueryString}', accessKey='{AccessKey}', nonce='{Nonce}', timestamp='{Timestamp}'}}";
        }
    }
}