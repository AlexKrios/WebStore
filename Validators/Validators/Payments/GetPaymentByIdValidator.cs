using CommandAndQuerySeparation.Queries.Payments;
using FluentValidation;

namespace Validators.Validators.Payments 
{
    public class GetPaymentByIdValidator : AbstractValidator<GetPaymentByIdQuery>
    {
        public GetPaymentByIdValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("Id must be entered");
        }
    }
}
