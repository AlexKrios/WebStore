using FluentValidation;
using WebStoreAPI.Requests.UsersRoles;

namespace Validators.Validators.UsersRoles 
{
    public class GetAllUserRolesByIdValidator : AbstractValidator<GetUsersRolesRequest>
    {
        public GetAllUserRolesByIdValidator()
        {
            
        }
    }
}
