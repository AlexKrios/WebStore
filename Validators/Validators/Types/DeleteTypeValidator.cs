using CommandAndQuerySeparation.Commands.Types;
using FluentValidation;

namespace Validators.Validators.Types
{
    public class DeleteTypeValidator : AbstractValidator<DeleteTypeCommand>
    {
        public DeleteTypeValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("Input correct id");
        }
    }
}
