using CQS.Commands.Countries;
using FluentValidation;

namespace Validators.Validators.Countries
{
    public class CreateCountryValidator : AbstractValidator<CreateCountryCommand>
    {
        public CreateCountryValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Name must be entered");
        }
    }
}
