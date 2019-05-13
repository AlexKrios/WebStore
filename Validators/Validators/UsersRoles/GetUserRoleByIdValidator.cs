using CQS.Queries.UsersRoles;
using FluentValidation;

namespace Validators.Validators.UsersRoles 
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
