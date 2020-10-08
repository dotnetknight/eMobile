using System.Collections.Generic;

namespace eMobile.Models.ViewModels
{
    public class PhoneViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Manufacturer { get; set; }
        public PhoneDimensionsViewModel Dimensions { get; set; }
        public List<PhoneMediaViewModel> Media { get; set; }
        public PhoneDisplayViewModel Display { get; set; }
        public double Weight { get; set; }
        public string CPUModel { get; set; }
        public int RAM { get; set; }
        public string OS { get; set; }
        public double Price { get; set; }
    }
}
