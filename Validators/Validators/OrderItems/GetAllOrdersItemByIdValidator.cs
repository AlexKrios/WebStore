using FluentValidation;
using WebStoreAPI.Requests.OrderItems;

namespace Validators.Validators.OrderItems 
{
    public class GetAllOrdersItemByIdValidator : AbstractValidator<GetOrdersItemsRequest>
    {
        public GetAllOrdersItemByIdValidator()
        {
            
        }
    }
}
