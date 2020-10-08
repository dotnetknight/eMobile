using eMobile.Domain.UsersEntity;

namespace eMobile.Domain.AddressEntity
{
    public class Address : BaseEntity
    {
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public string Phone { get; set; }
        public bool IsPrimary { get; set; }
        public Users User { get; set; }
        public int UserId { get; set; }
    }
}
