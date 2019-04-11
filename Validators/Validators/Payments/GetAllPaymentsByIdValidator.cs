using CommandAndQuerySeparation.Queries.Payments;
using FluentValidation;

namespace Validators.Validators.Payments 
{
    public class GetAllPaymentsByIdValidator : AbstractValidator<GetAllPaymentsQuery>
    {
        public GetAllPaymentsByIdValidator()
        {
            
        }
    }
}
