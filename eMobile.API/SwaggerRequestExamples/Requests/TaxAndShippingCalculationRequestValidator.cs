using eMobile.API.Requests;
using FluentValidation;

namespace eMobile.API.SwaggerRequestExamples.Requests
{
    public class TaxAndShippingCalculationRequestValidator : AbstractValidator<TaxAndShippingCalculationRequest>
    {
        public TaxAndShippingCalculationRequestValidator()
        {
            RuleFor(t => t.Height)
                .NotEmpty()
                .WithMessage("Item height is required");

            RuleFor(t => t.Length)
                .NotEmpty()
                .WithMessage("Item length is required");

            RuleFor(t => t.Width)
                .NotEmpty()
                .WithMessage("Item width is required");
        }
    }
}
