using CQRS.Interfaces;
using System.Collections.Generic;

namespace eMobile.API.Commands
{
    public class AddUserCommand : ICommand
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public List<UserAddress> Addresses { get; set; }
    }

    public class UserAddress
    {
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public string Phone { get; set; }
        public bool IsPrimary { get; set; }
    }
}
