using CQS.Commands.UsersRoles;
using FluentValidation;

namespace Validators.Validators.UsersRoles
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
