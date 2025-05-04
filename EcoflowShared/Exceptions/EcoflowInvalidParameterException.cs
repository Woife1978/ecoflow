using System;

namespace EcoflowShared.exceptions
{
    public class EcoflowInvalidParameterException : Exception
    {
        public EcoflowInvalidParameterException(string message)
            : base(message)
        {
        }
    }
}