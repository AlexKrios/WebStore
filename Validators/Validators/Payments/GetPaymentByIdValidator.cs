using FluentValidation;
using WebStoreAPI.Requests.Payments;

namespace Validators.Validators.Payments 
{
    public class GetPaymentByIdValidator : AbstractValidator<GetPaymentRequest>
    {
        public GetPaymentByIdValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("Id must be entered");
        }
    }
}
