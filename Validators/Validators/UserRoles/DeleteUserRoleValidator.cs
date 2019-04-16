using CQS.Commands.UserRoles;
using FluentValidation;

namespace Validators.Validators.UserRoles
{
    public class DeleteUserRoleValidator : AbstractValidator<DeleteUserRoleCommand>
    {
        public DeleteUserRoleValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("Input correct id");
        }
    }
}
