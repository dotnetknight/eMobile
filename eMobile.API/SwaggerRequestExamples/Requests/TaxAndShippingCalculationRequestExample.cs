using eMobile.API.Requests;
using Swashbuckle.AspNetCore.Filters;

namespace eMobile.API.SwaggerRequestExamples.Requests
{
    public class TaxAndShippingCalculationRequestExample : IExamplesProvider<TaxAndShippingCalculationRequest>
    {
        public TaxAndShippingCalculationRequest GetExamples()
        {
            return new TaxAndShippingCalculationRequest
            {
                Height = 10,
                Length = 5,
                Width = 2.3
            };
        }
    }
}
