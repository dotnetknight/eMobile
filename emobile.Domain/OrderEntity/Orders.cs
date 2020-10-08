using eMobile.Domain.UsersEntity;
using System.Collections.Generic;

namespace eMobile.Domain.OrderEntity
{
    public class Orders : BaseEntity
    {
        public string CreditCardNumber { get; set; }
        public string NameOnCard { get; set; }
        public Users User { get; set; }
        public int UserId { get; set; }
        public int PhoneId { get; set; }
    }
}