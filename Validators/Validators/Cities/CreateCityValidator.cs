using FluentValidation;
using WebStoreAPI.Requests.Cities;

namespace Validators.Validators.Cities
{
    public class CreateCityValidator : AbstractValidator<CreateCityRequest>
    {
        public CreateCityValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Name must be entered");

            RuleFor(x => x.CountryId)
                .NotEmpty()
                .WithMessage("Please specify a correct country id");
        }
    }
}
