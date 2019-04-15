using CQS.Commands.Payments;
using FluentValidation;

namespace Validators.Validators.Payments
{
    public class DeletePaymentValidator : AbstractValidator<DeletePaymentCommand>
    {
        public DeletePaymentValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("Input correct id");
        }
    }
}
