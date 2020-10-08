using System.Net;

namespace eMobile.Models.Exceptions
{
    public class WrongEmailOrPassword : BaseApiException
    {
        public WrongEmailOrPassword(HttpStatusCode responseHttpStatusCode, string message)
        {
            ResponseHttpStatusCode = responseHttpStatusCode;
            BackEndMessage = message;
        }
    }
}
