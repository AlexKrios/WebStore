using FluentValidation;
using WebStoreAPI.Commands.Users;

namespace WebStoreAPI.Validators.Users
{
    public class DeleteUserValidator : AbstractValidator<DeleteUserCommand>
    {
        public DeleteUserValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThanOrEqualTo(0);
        }
    }
}
