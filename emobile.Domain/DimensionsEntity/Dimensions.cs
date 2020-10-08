using eMobile.Domain.PhoneEntity;
using System.Collections.Generic;

namespace eMobile.Domain.DimensionsEntity
{
    public class Dimensions : BaseEntity
    {
        public Phone Phone { get; set; }
        public double Length { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
        public int PhoneId { get; set; }
    }
}
