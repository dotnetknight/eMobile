using eMobile.API.Commands;
using FluentValidation;
using FluentValidation.Validators;

namespace eMobile.API.Validators
{
    public class AddUserCommandValidator : AbstractValidator<AddUserCommand>
    {
        [System.Obsolete]
        public AddUserCommandValidator()
        {
            RuleFor(l => l.Email)
                .NotEmpty()
                .WithMessage("Email is required")
                .EmailAddress(EmailValidationMode.Net4xRegex)
                .WithMessage("Email is not in correct format");

            RuleFor(l => l.Password)
                .NotEmpty()
                .WithMessage("Password is required!");

            RuleFor(l => l.FirstName)
                .NotEmpty()
                .WithMessage("First name is required!");

            RuleFor(l => l.LastName)
                .NotEmpty()
                .WithMessage("Last name is required!");
        }
    }
}
