using CommandAndQuerySeparation.Queries.Payments;
using FluentValidation;

namespace Validators.Validators.Payments 
{
    public class GetPaymentByIdValidator : AbstractValidator<GetPaymentQuery>
    {
        public GetPaymentByIdValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("Id must be entered");
        }
    }
}
