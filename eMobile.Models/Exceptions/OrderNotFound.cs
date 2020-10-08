using System.Net;

namespace eMobile.Models.Exceptions
{
    public class OrderNotFound : BaseApiException
    {
        public OrderNotFound(HttpStatusCode responseHttpStatusCode, string message)
        {
            ResponseHttpStatusCode = responseHttpStatusCode;
            BackEndMessage = message;
        }
    }
}
