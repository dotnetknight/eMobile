using eMobile.API.Requests;
using Swashbuckle.AspNetCore.Filters;

namespace eMobile.API.SwaggerRequestExamples.Requests
{
    public class AuthenticationRequestExample : IExamplesProvider<AuthenticationRequest>
    {
        public AuthenticationRequest GetExamples()
        {
            return new AuthenticationRequest
            {
                Email = "nika@gmail.com",
                Password = "123"
            };
        }
    }
}