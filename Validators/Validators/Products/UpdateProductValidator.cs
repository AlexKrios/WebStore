using FluentValidation;
using WebStoreAPI.Requests.Products;

namespace Validators.Validators.Products
{
    public class UpdateProductValidator : AbstractValidator<UpdateProductRequest>
    {
        public UpdateProductValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty();

            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Name must be entered");

            RuleFor(x => x.Description)
                .NotEmpty()
                .WithMessage("Description must be entered");

            RuleFor(x => x.Availability)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Please specify a correct availability");

            RuleFor(x => x.Price)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Please specify a correct price");

            RuleFor(x => x.TypeId)
                .NotEmpty()
                .WithMessage("Please specify a correct type id");

            RuleFor(x => x.ManufacturerId)
                .NotEmpty()
                .WithMessage("Please specify a correct manufacturer id");
        }
    }
}
