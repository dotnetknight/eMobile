using System.Net;

namespace eMobile.Models.Exceptions
{
    public class UserNotFound : BaseApiException
    {
        public UserNotFound(HttpStatusCode responseHttpStatusCode, string message)
        {
            ResponseHttpStatusCode = responseHttpStatusCode;
            BackEndMessage = message;
        }
    }
}
