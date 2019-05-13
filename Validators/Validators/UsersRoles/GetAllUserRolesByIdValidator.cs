using CQS.Queries.UsersRoles;
using FluentValidation;

namespace Validators.Validators.UsersRoles 
{
    public class GetAllUserRolesByIdValidator : AbstractValidator<GetUsersRolesQuery>
    {
        public GetAllUserRolesByIdValidator()
        {
            
        }
    }
}
