using System.Net;

namespace eMobile.Models.Exceptions
{
    public class PhoneNotFound : BaseApiException
    {

        public PhoneNotFound(HttpStatusCode responseHttpStatusCode, string message)
        {
            ResponseHttpStatusCode = responseHttpStatusCode;
            BackEndMessage = message;
        }
    }
}
