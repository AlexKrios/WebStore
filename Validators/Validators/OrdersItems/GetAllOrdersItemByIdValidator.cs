using CQS.Queries.OrdersItems;
using FluentValidation;

namespace Validators.Validators.OrdersItems 
{
    public class GetAllOrdersItemByIdValidator : AbstractValidator<GetOrdersItemsQuery>
    {
        public GetAllOrdersItemByIdValidator()
        {
            
        }
    }
}
