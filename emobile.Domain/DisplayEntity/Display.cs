
using eMobile.Domain.PhoneEntity;

namespace eMobile.Domain.DisplayEntity
{
    public class Display : BaseEntity
    {
        public Phone Phone { get; set; }
        public double Size { get; set; }
        public int VerticalResolution { get; set; }
        public int HorizontalResolution { get; set; }
        public int PhoneId { get; set; }
    }
}
