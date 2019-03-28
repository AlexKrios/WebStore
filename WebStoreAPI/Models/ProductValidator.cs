using FluentValidation;

namespace WebStoreAPI.Models
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(t => t.Name).NotEmpty().Length(1, 50);
            RuleFor(t => t.Model).NotEmpty().Length(1, 50);
            RuleFor(t => t.Type).NotEmpty().Length(1, 50);
            RuleFor(t => t.Price).NotEmpty();
            RuleFor(t => t.Path).NotEmpty();
        }
    }
}
