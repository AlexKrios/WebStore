using CommandAndQuerySeparation.Commands.Products;
using FluentValidation;

namespace WebStoreAPI.Validators.Products
{
    public class DeleteProductValidator : AbstractValidator<DeleteProductCommand>
    {
        public DeleteProductValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("Input correct id");
        }
    }
}
