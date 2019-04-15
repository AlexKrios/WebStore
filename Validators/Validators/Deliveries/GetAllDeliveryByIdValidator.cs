using CommandAndQuerySeparation.Queries.Deliveries;
using FluentValidation;

namespace Validators.Validators.Deliveries 
{
    public class GetAllDeliveryByIdValidator : AbstractValidator<GetDeliveriesQuery>
    {
        public GetAllDeliveryByIdValidator()
        {
            
        }
    }
}
