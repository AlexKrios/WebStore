using CQS.Queries.Countries;
using FluentValidation;

namespace Validators.Validators.Countries 
{
    public class GetCountryByIdValidator : AbstractValidator<GetCountryQuery>
    {
        public GetCountryByIdValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("Id must be entered");
        }
    }
}
