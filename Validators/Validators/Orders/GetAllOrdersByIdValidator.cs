using FluentValidation;
using WebStoreAPI.Requests.Orders;

namespace Validators.Validators.Orders 
{
    public class GetAllOrdersByIdValidator : AbstractValidator<GetOrdersRequest>
    {
        public GetAllOrdersByIdValidator()
        {
            
        }
    }
}
