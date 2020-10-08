using eMobile.API.Commands;
using Swashbuckle.AspNetCore.Filters;
using System.Collections.Generic;

namespace eMobile.API.SwaggerRequestExamples.Requests
{
    public class UpdateMediaCommandRequestExample : IExamplesProvider<UpdateMediaCommand>
    {
        public UpdateMediaCommand GetExamples()
        {
            return new UpdateMediaCommand
            {
                Media = new List<PhoneMedia>
                {
                    new PhoneMedia{ Video="https://www.youtube.com/watch?v=xEEauoSSf1U", Photo="https://fdn2.gsmarena.com/vv/bigpic/samsung-galaxy-a8-a9-star.jpg"},
                    new PhoneMedia { Video = "https://www.youtube.com/watch?v=JdS07xXt4ps", Photo = "https://fdn2.gsmarena.com/vv/pics/samsung/samsung-galaxy-a8-a9-star-1.jpg" }
                 }
            };
        }
    }
}
