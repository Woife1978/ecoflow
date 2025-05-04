using System;

namespace EcoflowShared.exceptions
{
    public class EcoflowException : Exception
    {
        public EcoflowException(Exception innerException)
            : base("An error occurred in the Ecoflow application.", innerException)
        {
        }
    }
}