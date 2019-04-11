using CommandAndQuerySeparation.Queries.Countries;
using FluentValidation;

namespace Validators.Validators.Countries 
{
    public class GetCountryByIdValidator : AbstractValidator<GetCountryByIdQuery>
    {
        public GetCountryByIdValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("Id must be entered");
        }
    }
}
