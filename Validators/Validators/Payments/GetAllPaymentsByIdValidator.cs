using CommandAndQuerySeparation.Queries.Payments;
using FluentValidation;

namespace Validators.Validators.Payments 
{
    public class GetAllPaymentsByIdValidator : AbstractValidator<GetPaymentsQuery>
    {
        public GetAllPaymentsByIdValidator()
        {
            
        }
    }
}
