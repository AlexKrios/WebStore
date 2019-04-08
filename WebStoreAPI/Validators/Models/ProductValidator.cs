using DataLibrary.Entities;
using FluentValidation;

namespace WebStoreAPI.Validators.Models
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty();

            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Name must be entered");

            RuleFor(x => x.Description)
                .NotEmpty()
                .WithMessage("Description must be entered");

            RuleFor(x => x.Availability)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Please specify a correct availability");

            RuleFor(x => x.Price)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Please specify a correct price");
        }
    }
}
