using CommandAndQuerySeparation.Queries.Users;
using FluentValidation;

namespace Validators.Validators.Users 
{
    public class GetAllUsersByIdValidator : AbstractValidator<GetUsersQuery>
    {
        public GetAllUsersByIdValidator()
        {
            
        }
    }
}
