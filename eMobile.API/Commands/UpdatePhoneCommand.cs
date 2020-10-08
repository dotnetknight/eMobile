using CQRS.Interfaces;

namespace eMobile.API.Commands
{
    public class UpdatePhoneCommand : ICommand
    {
        public string Name { get; set; }
        public string Manufacturer { get; set; }
        public double Weight { get; set; }
        public string CPUModel { get; set; }
        public int RAM { get; set; }
        public string OS { get; set; }
        public double Price { get; set; }
    }
}
