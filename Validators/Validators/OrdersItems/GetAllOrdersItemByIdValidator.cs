using FluentValidation;
using WebStoreAPI.Requests.OrdersItems;

namespace Validators.Validators.OrdersItems 
{
    public class GetAllOrdersItemByIdValidator : AbstractValidator<GetOrdersItemsRequest>
    {
        public GetAllOrdersItemByIdValidator()
        {
            
        }
    }
}
