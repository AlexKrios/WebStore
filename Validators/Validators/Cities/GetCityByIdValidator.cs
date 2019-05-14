using FluentValidation;
using WebStoreAPI.Requests.Cities;

namespace Validators.Validators.Cities 
{
    public class GetCityByIdValidator : AbstractValidator<GetCityRequest>
    {
        public GetCityByIdValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("Id must be entered");
        }
    }
}
