using CommandAndQuerySeparation.Commands.Cities;
using FluentValidation;

namespace Validators.Validators.Cities
{
    public class CreateCityValidator : AbstractValidator<CreateCityCommand>
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
