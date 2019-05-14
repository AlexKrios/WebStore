using FluentValidation;
using WebStoreAPI.Requests.UsersRoles;

namespace Validators.Validators.UsersRoles
{
    public class UpdateUserRoleValidator : AbstractValidator<UpdateUserRolesRequest>
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
