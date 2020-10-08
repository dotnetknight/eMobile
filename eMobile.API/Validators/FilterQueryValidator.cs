using eMobile.API.Queries;
using FluentValidation;

namespace eMobile.API.Validators
{
    public class FilterQueryValidator : AbstractValidator<FilterQuery>
    {
        public FilterQueryValidator()
        {
            RuleFor(r => r.PriceTo)
                .GreaterThanOrEqualTo(r => r.PriceFrom)
                .WithMessage("'Price to' must be greater than 'price from'");


        }
    }
}
