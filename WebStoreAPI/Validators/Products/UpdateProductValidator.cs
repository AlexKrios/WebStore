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
