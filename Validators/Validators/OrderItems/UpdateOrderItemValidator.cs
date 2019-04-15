using CommandAndQuerySeparation.Commands.OrderItems;
using FluentValidation;

namespace Validators.Validators.OrderItems
{
    public class UpdateOrderItemValidator : AbstractValidator<UpdateOrderItemsCommand>
    {
        public UpdateOrderItemValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty();

            RuleFor(x => x.Count)
                .NotEmpty()
                .GreaterThanOrEqualTo(0)
                .WithMessage("Please specify a correct count");

            RuleFor(x => x.Price)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Please specify a correct price");

            RuleFor(x => x.ProductId)
                .NotEmpty()
                .WithMessage("Please specify a correct product id");

            RuleFor(x => x.OrderId)
                .NotEmpty()
                .WithMessage("Please specify a correct order id");
        }
    }
}
