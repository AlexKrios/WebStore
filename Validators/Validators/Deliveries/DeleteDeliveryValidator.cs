using CQS.Commands.Deliveries;
using FluentValidation;

namespace Validators.Validators.Deliveries
{
    public class DeleteDeliveryValidator : AbstractValidator<DeleteDeliveryCommand>
    {
        public DeleteDeliveryValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("Input correct id");
        }
    }
}
