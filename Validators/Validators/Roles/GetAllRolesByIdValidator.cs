using CQS.Queries.Roles;
using FluentValidation;

namespace Validators.Validators.Roles 
{
    public class GetAllRolesByIdValidator : AbstractValidator<GetRolesQuery>
    {
        public GetAllRolesByIdValidator()
        {
            
        }
    }
}
