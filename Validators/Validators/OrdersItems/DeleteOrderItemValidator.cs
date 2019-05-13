using CQS.Commands.OrdersItems;
using FluentValidation;

namespace Validators.Validators.OrdersItems
{
    public class DeleteOrderItemValidator : AbstractValidator<DeleteOrderItemsCommand>
    {
        public DeleteOrderItemValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("Input correct id");
        }
    }
}
