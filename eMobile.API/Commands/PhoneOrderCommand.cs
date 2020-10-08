using CQRS.Interfaces;

namespace eMobile.API.Commands
{
    public class PhoneOrderCommand : ICommand
    {
        public int PhoneId { get; set; }
        public string CreditCardNumber { get; set; }
        public string NameOnCard { get; set; }
    }
}
