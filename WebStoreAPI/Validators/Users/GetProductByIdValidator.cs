using FluentValidation;
using WebStoreAPI.Queries.Users;

namespace WebStoreAPI.Validators.Users 
{
    public class GetUserByIdValidator : AbstractValidator<GetUserByIdQuery>
    {
        public GetUserByIdValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThanOrEqualTo(0);
        }
    }
}
