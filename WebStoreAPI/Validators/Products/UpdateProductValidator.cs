using FluentValidation;
using WebStoreAPI.Commands.Products;

namespace WebStoreAPI.Validators.Products
{
    public class UpdateProductValidator : AbstractValidator<UpdateProductCommand>
    {
        public UpdateProductValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty();

            RuleFor(x => x.Name)
                .NotNull()
                .WithMessage("Name must be entered");

            RuleFor(x => x.Model)
                .NotNull()
                .WithMessage("Model must be entered");

            RuleFor(x => x.Type)
                .NotNull()
                .WithMessage("Type must be entered");

            RuleFor(x => x.Price)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Please specify correct price");
        }
    }
}
