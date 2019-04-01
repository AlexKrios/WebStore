using FluentValidation;
using WebStoreAPI.Commands.Users;

namespace WebStoreAPI.Validators.Users
{
    public class UpdateUserValidator : AbstractValidator<UpdateUserCommand>
    {
        public UpdateUserValidator()
        {
            RuleFor(x => x.User)
                .NotEmpty();
        }
    }
}
