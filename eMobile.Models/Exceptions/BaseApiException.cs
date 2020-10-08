using System;
using System.Net;

namespace eMobile.Models.Exceptions
{
    public class BaseApiException : Exception
    {
        public HttpStatusCode ResponseHttpStatusCode { get; set; }

        public string BackEndMessage { get; set; }
    }
}
