using FluentValidation;
using WebStoreAPI.Commands.Products;

namespace WebStoreAPI.Validators.Products
{
    public class CreateProductValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductValidator()
        {
            RuleFor(x => x.Product)
                .NotEmpty();
        }
    }
}
