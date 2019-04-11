using CommandAndQuerySeparation.Commands.Orders;
using FluentValidation;

namespace Validators.Validators.Orders
{
    public class DeleteOrderValidator : AbstractValidator<DeleteOrderCommand>
    {
        public DeleteOrderValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("Input correct id");
        }
    }
}
