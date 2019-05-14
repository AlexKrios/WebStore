using FluentValidation;
using WebStoreAPI.Requests.Roles;

namespace Validators.Validators.Roles 
{
    public class GetAllRolesByIdValidator : AbstractValidator<GetRolesRequest>
    {
        public GetAllRolesByIdValidator()
        {
            
        }
    }
}
