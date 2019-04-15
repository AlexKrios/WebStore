using CQS.Commands.Countries;
using FluentValidation;

namespace Validators.Validators.Countries
{
    public class DeleteCountryValidator : AbstractValidator<DeleteCountryCommand>
    {
        public DeleteCountryValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("Input correct id");
        }
    }
}
