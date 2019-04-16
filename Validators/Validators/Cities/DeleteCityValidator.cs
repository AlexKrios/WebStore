using CQS.Commands.Cities;
using FluentValidation;

namespace Validators.Validators.Cities
{
    public class DeleteCityValidator : AbstractValidator<DeleteCityCommand>
    {
        public DeleteCityValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("Input correct id");
        }
    }
}
