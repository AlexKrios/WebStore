using FluentValidation;
using WebStoreAPI.Requests.Payments;

namespace Validators.Validators.Payments
{
    public class UpdatePaymentValidator : AbstractValidator<UpdatePaymentRequest>
    {
        public UpdatePaymentValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty();

            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Name must be entered");

            RuleFor(x => x.Description)
                .NotEmpty()
                .WithMessage("Description must be entered");

            RuleFor(x => x.Taxes)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Please specify a correct taxes");
        }
    }
}
