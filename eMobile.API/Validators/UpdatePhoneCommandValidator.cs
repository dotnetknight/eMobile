using eMobile.API.Commands;
using FluentValidation;

namespace eMobile.API.Validators
{
    public class UpdatePhoneCommandValidator : AbstractValidator<UpdatePhoneCommand>
    {
        public UpdatePhoneCommandValidator()
        {
            RuleFor(l => l.Name)
                .NotEmpty()
                .WithMessage("Name is required!")
                .NotEqual("string")
                .WithMessage("Name can't equal to 'string'");

            RuleFor(l => l.CPUModel)
                .NotEmpty()
                .WithMessage("CPU Model is required!");

            RuleFor(l => l.Manufacturer)
                .NotEmpty()
                .WithMessage("Manufacturer is required!")
                .NotEqual("string")
                .WithMessage("Manufacturer name can't equal to 'string'");

            RuleFor(l => l.Weight)
                .NotEmpty()
                .WithMessage("Weight is required!");

            RuleFor(l => l.RAM)
                .NotEmpty()
                .WithMessage("RAM is required!");

            RuleFor(l => l.Price)
                .NotEmpty()
                .WithMessage("Price is required!");
        }
    }
}
