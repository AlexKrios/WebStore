using CQS.Commands.Orders;
using FluentValidation;

namespace Validators.Validators.Orders
{
    public class CreateOrderValidator : AbstractValidator<CreateOrderCommand>
    {
        public CreateOrderValidator()
        {
            RuleFor(x => x.CustomerNumber)
                .NotEmpty()
                .WithMessage("Customer number must be entered");

            RuleFor(x => x.Note)
                .NotEmpty()
                .WithMessage("Note must be entered");

            RuleFor(x => x.TotalPrice)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Please specify a correct total price");

            RuleFor(x => x.UserId)
                .NotEmpty()
                .WithMessage("Please specify a correct user id");

            RuleFor(x => x.DeliveryId)
                .NotEmpty()
                .WithMessage("Please specify a correct delivery id");

            RuleFor(x => x.PaymentId)
                .NotEmpty()
                .WithMessage("Please specify a correct payment id");
        }
    }
}
