using eMobile.Domain.PhoneEntity;
using eMobile.Models.Exceptions;

namespace eMobile.Services
{
    public class ValidatePhoneService : IValidation
    {
        public void Validate(Phone phone)
        {
            if (phone == null)
            {
                throw new PhoneNotFound(System.Net.HttpStatusCode.NotFound, $"Requested phone with id:{ phone.Id } not found");
            }
        }
    }
}
