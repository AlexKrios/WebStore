using CQS.Commands.UserRoles;
using FluentValidation;

namespace Validators.Validators.UserRoles
{
    public class UpdateUserRoleValidator : AbstractValidator<UpdateUserRoleCommand>
    {
        public UpdateUserRoleValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty();

            RuleFor(x => x.UserId)
                .NotEmpty()
                .WithMessage("Please specify a correct user id");

            RuleFor(x => x.RoleId)
                .NotEmpty()
                .WithMessage("Please specify a correct role id");
        }
    }
}
