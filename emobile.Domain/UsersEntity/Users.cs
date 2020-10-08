using eMobile.Domain.AddressEntity;
using eMobile.Domain.OrderEntity;
using System.Collections.Generic;

namespace eMobile.Domain.UsersEntity
{
    public class Users : BaseEntity
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public List<Address> Address { get; set; }
        public List<Orders> Order { get; set; }
    }
}
