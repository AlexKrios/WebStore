using CommandAndQuerySeparation.Queries.Cities;
using FluentValidation;

namespace Validators.Validators.Cities 
{
    public class GetCityByIdValidator : AbstractValidator<GetCityByIdQuery>
    {
        public GetCityByIdValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("Id must be entered");
        }
    }
}
