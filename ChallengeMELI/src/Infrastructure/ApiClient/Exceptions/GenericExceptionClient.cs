using System;
using System.Globalization;
using System.Net;

namespace Challenge.MELI.ApiClient.Exceptions
{
    public class GenericExceptionClient : Exception
    {
        public string ErrorMessage { get; set; }
        public HttpStatusCode HttpStatusCode { get; set; }
        public GenericExceptionClient() : base()
        {
        }

        public GenericExceptionClient(string message, string errorMessage, HttpStatusCode httpStatusCode) : base(message)
        {
            ErrorMessage = errorMessage;
            HttpStatusCode = httpStatusCode;
        }

        public GenericExceptionClient(string message, params object[] args) : base(String.Format(CultureInfo.CurrentCulture, message, args))
        {
        }
    }
}
