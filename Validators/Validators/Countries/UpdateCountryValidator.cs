using FluentValidation;
using WebStoreAPI.Requests.Countries;

namespace Validators.Validators.Countries
{
    public class UpdateCountryValidator : AbstractValidator<UpdateCountryRequest>
    {
        public UpdateCountryValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty();

            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Name must be entered");
        }
    }
}
