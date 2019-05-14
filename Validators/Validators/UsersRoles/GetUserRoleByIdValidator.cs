using FluentValidation;
using WebStoreAPI.Requests.UsersRoles;

namespace Validators.Validators.UsersRoles 
{
    public class GetUserRoleByIdValidator : AbstractValidator<GetUserRolesRequest>
    {
        public GetUserRoleByIdValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("Id must be entered");
        }
    }
}
