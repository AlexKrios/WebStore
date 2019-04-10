using CommandAndQuerySeparation.Commands.Products;
using FluentValidation;

namespace WebStoreAPI.Validators.Products
{
    public class CreateProductValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Name must be entered");

            RuleFor(x => x.Description)
                .NotEmpty()
                .WithMessage("Name must be entered");

            RuleFor(x => x.Availability)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Please specify a correct price");

            RuleFor(x => x.Price)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Please specify a correct price");

            RuleFor(x => x.TypeId)
                .NotEmpty();

            RuleFor(x => x.ManufacturerId)
                .NotEmpty();
        }
    }
}
