using FluentValidation;
using WebStoreAPI.Requests.Countries;

namespace Validators.Validators.Countries 
{
    public class GetCountryByIdValidator : AbstractValidator<GetCountryRequest>
    {
        public GetCountryByIdValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("Id must be entered");
        }
    }
}
