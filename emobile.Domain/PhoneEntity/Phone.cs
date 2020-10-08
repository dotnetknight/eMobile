using eMobile.Domain.DimensionsEntity;
using eMobile.Domain.DisplayEntity;
using eMobile.Domain.MediaEntity;
using eMobile.Domain.OrderEntity;
using System.Collections.Generic;

namespace eMobile.Domain.PhoneEntity
{
    public class Phone : BaseEntity
    {
        public string Name { get; set; }
        public string Manufacturer { get; set; }
        public Dimensions Dimensions { get; set; }
        public double Weight { get; set; }
        public Display Display { get; set; }
        public string CPUModel { get; set; }
        public int RAM { get; set; }
        public string OS { get; set; }
        public double Price { get; set; }
        public List<Media> Media { get; set; }
        public Orders Order { get; set; }
    }
}