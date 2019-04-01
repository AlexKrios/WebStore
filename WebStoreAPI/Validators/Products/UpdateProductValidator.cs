using FluentValidation;
using WebStoreAPI.Commands.Products;

namespace WebStoreAPI.Validators.Products
{
    public class UpdateProductValidator : AbstractValidator<UpdateProductCommand>
    {
        public UpdateProductValidator()
        {
            RuleFor(x => x.Product)
                .NotEmpty();
        }
    }
}
