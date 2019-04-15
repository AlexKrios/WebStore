using CommandAndQuerySeparation.Commands.UserRoles;
using FluentValidation;

namespace Validators.Validators.UserRoles
{
    public class CreateUserRoleValidator : AbstractValidator<CreateUserRoleCommand>
    {
        public CreateUserRoleValidator()
        {
            RuleFor(x => x.UserId)
                .NotEmpty()
                .WithMessage("Please specify a correct user id");

            RuleFor(x => x.RoleId)
                .NotEmpty()
                .WithMessage("Please specify a correct role id");
        }
    }
}
