using FluentValidation;
using WebStoreAPI.Commands.Users;

namespace WebStoreAPI.Validators.Users
{
    public class CreateUserValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserValidator()
        {
            RuleFor(x => x.User)
                .NotEmpty();
        }
    }
}
