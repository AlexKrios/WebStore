using CQS.Commands.Types;
using FluentValidation;

namespace Validators.Validators.Types
{
    public class UpdateTypeValidator : AbstractValidator<UpdateTypeCommand>
    {
        public UpdateTypeValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty();

            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Name must be entered");
        }
    }
}
