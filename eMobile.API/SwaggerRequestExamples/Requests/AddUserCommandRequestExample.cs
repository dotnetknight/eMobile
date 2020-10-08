using eMobile.API.Commands;
using Swashbuckle.AspNetCore.Filters;
using System.Collections.Generic;

namespace eMobile.API.SwaggerRequestExamples.Requests
{
    public class AddUserCommandRequestExample : IExamplesProvider<AddUserCommand>
    {
        public AddUserCommand GetExamples()
        {
            return new AddUserCommand
            {
                Email = "nika@gmail.com",
                FirstName = "Nika",
                LastName = "Qantaria",
                Password = "123",
                Addresses = new List<UserAddress> {
                    new UserAddress
                    {
                        Address1 ="",
                        Address2="",
                        City="",
                        IsPrimary=false,
                        Phone="",
                        ZipCode=""
                    }
                }
            };
        }
    }
}
