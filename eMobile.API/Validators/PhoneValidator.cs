using eMobile.Domain.PhoneEntity;
using eMobile.Models.Exceptions;

namespace eMobile.API.Validators
{
    public static class PhoneValidator
    {
        public static void Validate(Phone phone, int Id)
        {
            if (phone == null)
            {
                throw new PhoneNotFound(System.Net.HttpStatusCode.NotFound, $"Phone with the id: { Id } not found");
            }
        }
    }
}
