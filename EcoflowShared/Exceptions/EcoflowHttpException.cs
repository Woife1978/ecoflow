using System;

namespace EcoflowShared.exceptions
{
    public class EcoflowHttpException : Exception
    {
        public EcoflowHttpException(string message)
            : base(message)
        {
        }

        public EcoflowHttpException(Exception innerException)
            : base("An HTTP error occurred in the Ecoflow application.", innerException)
        {
        }
    }
}