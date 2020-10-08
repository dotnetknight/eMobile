using eMobile.API.Commands;
using Swashbuckle.AspNetCore.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eMobile.API.SwaggerRequestExamples.Requests
{
    public class AddPhoneCommandRequestExample : IExamplesProvider<AddPhoneCommand>
    {
        public AddPhoneCommand GetExamples()
        {
            return new AddPhoneCommand
            {
                CPUModel = "Octa-core (4x2.2 GHz Kryo 260 Gold & 4x1.8 GHz Kryo 260 Silver",

                Dimensions = new PhoneDimensions
                {
                    Height = 162.4,
                    Length = 77,
                    Width = 7.6
                },

                Display = new PhoneDisplay
                {
                    HorizontalResolution = 1080,
                    VerticalResolution = 2220,
                    Size = 6.3
                },

                Media = new List<PhoneMedia> 
                {
                    new PhoneMedia 
                    {
                      Photo ="https://fdn2.gsmarena.com/vv/bigpic/samsung-galaxy-a8-a9-star.jpg"  ,
                       Video = "https://www.youtube.com/watch?v=xEEauoSSf1U"
                    },

                   new PhoneMedia
                   {
                     Photo ="https://fdn2.gsmarena.com/vv/pics/samsung/samsung-galaxy-a8-a9-star-1.jpg",
                     Video ="https://www.youtube.com/watch?v=JdS07xXt4ps"
                   }
                },
                
                Manufacturer = "Samsung",
                Name = "A9 Star",
                OS = "Android 8",
                Price = 350,
                RAM = 6,
                Weight = 191
            };
        }
    }
}
