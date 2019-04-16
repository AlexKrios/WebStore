using CQS.Commands.Roles;
using FluentValidation;

namespace Validators.Validators.Roles
{
    public class CreateRoleValidator : AbstractValidator<CreateRoleCommand>
    {
        public CreateRoleValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Name must be entered");
        }
    }
}
