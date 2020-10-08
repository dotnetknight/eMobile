using eMobile.API.Commands;
using Swashbuckle.AspNetCore.Filters;

namespace eMobile.API.SwaggerRequestExamples.Requests
{
    public class UpdatePhoneCommandRequestExample : IExamplesProvider<UpdatePhoneCommand>
    {
        public UpdatePhoneCommand GetExamples()
        {
            return new UpdatePhoneCommand()
            {
                CPUModel = "A7",
                Manufacturer = "Apple",
                Name = "iPhone X",
                OS = "IOS 10",
                Price = 879.99,
                RAM = 3,
                Weight = 154
            };
        }
    }
}
