using FluentValidation;
using WebStoreAPI.Commands.Users;

namespace WebStoreAPI.Validators.Users
{
    public class CreateUserValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserValidator()
        {
            RuleFor(t => t.Name)
                .NotEmpty()
                .WithMessage("Name must be entered");

            RuleFor(t => t.Age)
                .NotEmpty()
                .GreaterThan(0)
                .WithMessage("Please specify correct age");

            RuleFor(t => t.Email)
                .NotEmpty()
                .WithMessage("Email must be entered");

            RuleFor(t => t.TelephoneNumber)
                .NotEmpty()
                .WithMessage("Telephone number must be entered");

            RuleFor(t => t.Address)
                .NotEmpty()
                .WithMessage("Address must be entered");

            RuleFor(t => t.CityId)
                .NotEmpty();
        }
    }
}
