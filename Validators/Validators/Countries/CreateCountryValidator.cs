using FluentValidation;
using WebStoreAPI.Requests.Countries;

namespace Validators.Validators.Countries
{
    public class CreateCountryValidator : AbstractValidator<CreateCountryRequest>
    {
        public CreateCountryValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Name must be entered");
        }
    }
}
