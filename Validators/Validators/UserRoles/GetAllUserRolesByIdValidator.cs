using CommandAndQuerySeparation.Queries.UserRoles;
using FluentValidation;

namespace Validators.Validators.UserRoles 
{
    public class GetAllUserRolesByIdValidator : AbstractValidator<GetAllUserRolesQuery>
    {
        public GetAllUserRolesByIdValidator()
        {
            
        }
    }
}
