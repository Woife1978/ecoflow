using System;
using System.Security.Cryptography;
using System.Text;
using EcoflowShared.exceptions;

namespace EcoflowShared.encryption
{
    public class EncryptionService
    {
        public const string HMAC_SHA_256 = "HMACSHA256";

        public string EncryptHmacSHA256(string message, string secret)
        {
            try
            {
                using (var hmac = new HMACSHA256(Encoding.UTF8.GetBytes(secret)))
                {
                    var hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(message));
                    return ToHexString(hash);
                }
            }
            catch (Exception e)
            {
                //"Error while encrypting with HMAC-SHA256", 
                throw new EcoflowException(e);
            }
        }

        private string ToHexString(byte[] bytes)
        {
            if (bytes == null)
            {
                return null;
            }

            var hexString = new StringBuilder();
            foreach (var b in bytes)
            {
                hexString.AppendFormat("{0:x2}", b);
            }
            return hexString.ToString();
        }
    }
}