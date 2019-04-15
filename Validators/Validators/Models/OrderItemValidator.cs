using DataLibrary.Entities;
using FluentValidation;

namespace Validators.Validators.Models
{
    public class OrderItemValidator : AbstractValidator<OrderItem>
    {
        public OrderItemValidator()
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
