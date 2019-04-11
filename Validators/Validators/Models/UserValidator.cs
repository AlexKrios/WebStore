using DataLibrary.Entities;
using FluentValidation;

namespace Validators.Validators.Models
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty();

            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Name must be entered");

            RuleFor(x => x.Age)
                .NotEmpty()
                .GreaterThan(0)
                .WithMessage("Please specify correct age");

            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage("Email must be entered");

            RuleFor(x => x.TelephoneNumber)
                .NotEmpty()
                .WithMessage("Telephone number must be entered");

            RuleFor(x => x.Address)
                .NotEmpty()
                .WithMessage("Address must be entered");

            RuleFor(x => x.CityId)
                .NotEmpty()
                .WithMessage("Please specify correct city id");
        }
    }
}
