using CQS.Commands.Countries;
using FluentValidation;

namespace Validators.Validators.Countries
{
    public class UpdateCountryValidator : AbstractValidator<UpdateCountryCommand>
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
