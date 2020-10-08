using eMobile.API.Requests;
using FluentValidation;
using FluentValidation.Validators;

namespace eMobile.API.Validators
{
    public class AuthenticationRequestValidator : AbstractValidator<AuthenticationRequest>
    {
        [System.Obsolete]
        public AuthenticationRequestValidator()
        {
            RuleFor(l => l.Email)
             .NotEmpty()
             .WithMessage("Email is required")
             .EmailAddress(EmailValidationMode.Net4xRegex)
             .WithMessage("Email is not in correct format");

            RuleFor(l => l.Password)
                .NotEmpty()
                .WithMessage("Password is required!");
        }
    }
}
