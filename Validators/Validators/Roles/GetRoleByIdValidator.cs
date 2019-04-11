using CommandAndQuerySeparation.Queries.Roles;
using FluentValidation;

namespace Validators.Validators.Roles 
{
    public class GetRoleByIdValidator : AbstractValidator<GetRoleByIdQuery>
    {
        public GetRoleByIdValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("Id must be entered");
        }
    }
}
