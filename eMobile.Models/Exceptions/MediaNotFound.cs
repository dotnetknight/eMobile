using System.Net;

namespace eMobile.Models.Exceptions
{
    public class MediaNotFound : BaseApiException
    {
        public MediaNotFound(HttpStatusCode responseHttpStatusCode, string message)
        {
            ResponseHttpStatusCode = responseHttpStatusCode;
            BackEndMessage = message;
        }
    }
}
