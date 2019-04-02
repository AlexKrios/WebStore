using FluentValidation;
using WebStoreAPI.Models;

namespace WebStoreAPI.Validators.Products
{
    public class CreateProductDtoValidator : AbstractValidator<Product>
    {
        public CreateProductDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Please specify a correct name");

            RuleFor(x => x.Model)
                .NotEmpty()
                .WithMessage("Please specify a correct model");

            RuleFor(x => x.Type)
                .NotEmpty()
                .WithMessage("Please specify a correct type");

            RuleFor(x => x.Price)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Please specify a correct price");
        }
    }
}
