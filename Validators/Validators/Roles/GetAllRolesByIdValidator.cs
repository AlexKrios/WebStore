using CommandAndQuerySeparation.Queries.Roles;
using FluentValidation;

namespace Validators.Validators.Roles 
{
    public class GetAllRolesByIdValidator : AbstractValidator<GetAllRolesQuery>
    {
        public GetAllRolesByIdValidator()
        {
            
        }
    }
}
