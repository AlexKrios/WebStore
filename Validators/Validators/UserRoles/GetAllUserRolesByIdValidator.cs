using FluentValidation;
using WebStoreAPI.Requests.UserRoles;

namespace Validators.Validators.UserRoles 
{
    public class GetAllUserRolesByIdValidator : AbstractValidator<GetUsersRolesRequest>
    {
        public GetAllUserRolesByIdValidator()
        {
            
        }
    }
}
