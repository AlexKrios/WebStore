using FluentValidation;
using WebStoreAPI.Requests.Roles;

namespace Validators.Validators.Roles 
{
    public class GetRoleByIdValidator : AbstractValidator<GetRoleRequest>
    {
        public GetRoleByIdValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("Id must be entered");
        }
    }
}
