using CQRS.Interfaces;

namespace eMobile.API.Queries
{
    public class FilterQuery : IQuery
    {
        public string Name { get; set; }
        public string Manufacturer { get; set; }
        public double PriceFrom { get; set; }
        public double PriceTo { get; set; }
        public int Page { get; set; } = 1;
        public int Limit { get; set; } = 3;
    }
}
