using System;

namespace EcoflowShared.exceptions
{
    public class EcoflowResponseParserException : Exception
    {
        public EcoflowResponseParserException(Exception innerException)
            : base("An error occurred while parsing the response.", innerException)
        {
        }
    }
}