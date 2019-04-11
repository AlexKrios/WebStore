using DataLibrary.Entities;
using FluentValidation;

namespace Validators.Validators.Models
{
    public class ManufacturerValidator : AbstractValidator<Manufacturer>
    {
        public ManufacturerValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty();

            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Name must be entered");

            RuleFor(x => x.Address)
                .NotEmpty()
                .WithMessage("Address must be entered");

            RuleFor(x => x.Contact)
                .NotEmpty()
                .WithMessage("Contact must be entered");

            RuleFor(x => x.Rating)
                .NotEmpty()
                .GreaterThanOrEqualTo(0)
                .LessThanOrEqualTo(5)
                .WithMessage("Please specify a correct rating");
        }
    }
}
