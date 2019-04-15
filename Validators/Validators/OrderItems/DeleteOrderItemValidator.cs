using CQS.Commands.OrderItems;
using FluentValidation;

namespace Validators.Validators.OrderItems
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
