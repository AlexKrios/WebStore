using CommandAndQuerySeparation.Commands.Cities;
using FluentValidation;

namespace Validators.Validators.Cities
{
    public class UpdateCityValidator : AbstractValidator<UpdateCityCommand>
    {
        public UpdateCityValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty();

            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Name must be entered");

            RuleFor(x => x.CountryId)
                .NotEmpty()
                .WithMessage("Please specify a correct country id");
        }
    }
}
