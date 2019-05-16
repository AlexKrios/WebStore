using FluentValidation;
using WebStoreAPI.Requests.UserRoles;

namespace Validators.Validators.UserRoles 
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
