using CQRS.Interfaces;

namespace eMobile.API.Queries
{
    public class OrderedPhoneQuery : IQuery
    {
        public int Id { get; set; }
    }
}
