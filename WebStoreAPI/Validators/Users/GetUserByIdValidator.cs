using CommandAndQuerySeparation.Queries.Users;
using FluentValidation;

namespace WebStoreAPI.Validators.Users 
{
    public class GetUserByIdValidator : AbstractValidator<GetUserByIdQuery>
    {
        public GetUserByIdValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty();
        }
    }
}
