using FluentValidation;
using WebStoreAPI.Queries.Users;

namespace WebStoreAPI.Validators.Users
{
    public class GetUsersByRoleValidator : AbstractValidator<GetUsersByRoleQuery>
    {
        public GetUsersByRoleValidator()
        {
            RuleFor(x => x.Role)
                .NotEmpty()
                .WithMessage("Input correct role");
        }
    }
}
