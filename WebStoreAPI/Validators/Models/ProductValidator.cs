using FluentValidation;
using WebStoreAPI.Models;

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

            RuleFor(x => x.Model)
                .NotEmpty()
                .WithMessage("Model must be entered");

            RuleFor(x => x.Type)
                .NotEmpty()
                .WithMessage("Type must be entered");

            RuleFor(x => x.Price)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Please specify a correct price");
        }
    }
}
