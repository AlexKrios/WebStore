using FluentValidation;
using WebStoreAPI.Queries.Users;

namespace WebStoreAPI.Validators.Users
{
    public class GetUsersByTypeValidator : AbstractValidator<GetUsersByRoleQuery>
    {
        public GetUsersByTypeValidator()
        {
            RuleFor(x => x.Role)
                .NotEmpty();
        }
    }
}
