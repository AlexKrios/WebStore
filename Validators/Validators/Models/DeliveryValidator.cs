using DataLibrary.Entities;
using FluentValidation;

namespace Validators.Validators.Models
{
    public class DeliveryValidator : AbstractValidator<Delivery>
    {
        public DeliveryValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty();

            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Name must be entered");

            RuleFor(x => x.Description)
                .NotEmpty()
                .WithMessage("Description must be entered");

            RuleFor(x => x.Price)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Please specify a correct price");

            RuleFor(x => x.Rating)
                .NotEmpty()
                .GreaterThanOrEqualTo(0)
                .LessThanOrEqualTo(5)
                .WithMessage("Please specify a correct rating");
        }
    }
}
