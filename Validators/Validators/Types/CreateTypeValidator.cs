using CQS.Commands.Types;
using FluentValidation;

namespace Validators.Validators.Types
{
    public class CreateTypeValidator : AbstractValidator<CreateTypeCommand>
    {
        public CreateTypeValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Name must be entered");
        }
    }
}
