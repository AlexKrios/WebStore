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
                .Length(1, 50)
                .WithMessage("Please specify a correct first name");

            RuleFor(t => t.LastName)
                .NotEmpty()
                .Length(1, 50)
                .WithMessage("Please specify a correct last name");

            RuleFor(t => t.Role)
                .NotEmpty()
                .Length(1, 50)
                .WithMessage("Please specify a correct role");

            RuleFor(t => t.Age)
                .NotEmpty()
                .GreaterThan(0)
                .WithMessage("Please specify correct age");
        }
    }
}
