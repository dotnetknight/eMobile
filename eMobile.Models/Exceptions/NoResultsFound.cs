using System.Net;

namespace eMobile.Models.Exceptions
{
    public class NoResultsFound : BaseApiException
    {
        public NoResultsFound(HttpStatusCode responseHttpStatusCode, string message)
        {
            ResponseHttpStatusCode = responseHttpStatusCode;
            BackEndMessage = message;
        }
    }
}
