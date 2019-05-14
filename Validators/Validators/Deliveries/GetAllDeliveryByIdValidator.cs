using FluentValidation;
using WebStoreAPI.Requests.Deliveries;

namespace Validators.Validators.Deliveries 
{
    public class GetAllDeliveryByIdValidator : AbstractValidator<GetDeliveriesRequest>
    {
        public GetAllDeliveryByIdValidator()
        {
            
        }
    }
}
