using System;
using System.Globalization;

namespace Challenge.MELI.ApiClient.Exceptions
{
    public class GenericException : Exception
    {
        public string ErrorMessage { get; set; }
        public GenericException() : base()
        {
        }

        public GenericException(string message, string errorMessage) : base(message)
        {
            ErrorMessage = errorMessage;
        }

        public GenericException(string message, params object[] args) : base(String.Format(CultureInfo.CurrentCulture, message, args))
        {
        }
    }
}
