using FluentValidation;
using WebStoreAPI.Commands.Users;

namespace WebStoreAPI.Validators.Users
{
    public class CreateUserValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserValidator()
        {
            RuleFor(t => t.FirstName)
                .NotEmpty()
                .WithMessage("First name must be entered");

            RuleFor(t => t.LastName)
                .NotEmpty()
                .WithMessage("Last name must be entered");

            RuleFor(t => t.Role)
                .NotEmpty()
                .Length(1, 50)
                .WithMessage("Role must be entered");

            RuleFor(t => t.Age)
                .NotEmpty()
                .GreaterThan(0)
                .WithMessage("Please specify correct age");
        }
    }
}
