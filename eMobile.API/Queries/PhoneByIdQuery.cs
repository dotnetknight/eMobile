using CQRS.Interfaces;

namespace eMobile.API.Queries
{
    public class PhoneQuery : IQuery
    {
        public int Id { get; set; }
    }
}
