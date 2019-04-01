using FluentValidation;

namespace WebStoreAPI.Models
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .Length(1, 50)
                .WithMessage("Please specify a correct name");

            RuleFor(x => x.Model)
                .NotEmpty()
                .Length(1, 50)
                .WithMessage("Please specify a correct model");

            RuleFor(x => x.Type)
                .NotEmpty()
                .Length(1, 50)
                .WithMessage("Please specify a correct type");

            RuleFor(x => x.Price)
                .NotEmpty()
                .WithMessage("Please specify a correct price");

            RuleFor(x => x.Path);
        }
    }
}
