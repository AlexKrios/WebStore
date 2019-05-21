using FluentValidation;
using WebStoreAPI.Requests.Payments;

namespace Validators.Validators.Payments 
{
    public class GetAllPaymentsByIdValidator : AbstractValidator<GetPaymentsRequest>
    {
        public GetAllPaymentsByIdValidator()
        {
            
        }
    }
}
