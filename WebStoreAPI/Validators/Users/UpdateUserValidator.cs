using FluentValidation;
using WebStoreAPI.Commands.Users;

namespace WebStoreAPI.Validators.Users
{
    public class UpdateUserValidator : AbstractValidator<UpdateUserCommand>
    {
        public UpdateUserValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty();

            RuleFor(x => x.FirstName)
                .NotEmpty()
                .WithMessage("First name must be entered");

            RuleFor(x => x.LastName)
                .NotEmpty()
                .WithMessage("Last name must be entered");

            RuleFor(x => x.Role)
                .NotEmpty()
                .Length(1, 50)
                .WithMessage("Role must be entered");

            RuleFor(x => x.Age)
                .NotEmpty()
                .GreaterThan(0)
                .WithMessage("Please specify correct age");
        }
    }
}
