using CommandAndQuerySeparation.Commands.Users;
using FluentValidation;

namespace Validators.Validators.Users
{
    public class DeleteUserValidator : AbstractValidator<DeleteUserCommand>
    {
        public DeleteUserValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("Input correct id");
        }
    }
}
