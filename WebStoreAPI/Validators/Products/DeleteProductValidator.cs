using FluentValidation;
using WebStoreAPI.Commands.Products;

namespace WebStoreAPI.Validators.Products
{
    public class DeleteProductValidator : AbstractValidator<DeleteProductCommand>
    {
        public DeleteProductValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThanOrEqualTo(0);
        }
    }
}
