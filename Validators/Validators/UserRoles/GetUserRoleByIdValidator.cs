using CommandAndQuerySeparation.Queries.Cities;
using CommandAndQuerySeparation.Queries.UserRoles;
using FluentValidation;

namespace Validators.Validators.UserRoles 
{
    public class GetUserRoleByIdValidator : AbstractValidator<GetUserRoleQuery>
    {
        public GetUserRoleByIdValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("Id must be entered");
        }
    }
}
