using CommandAndQuerySeparation.Queries.OrderItems;
using FluentValidation;

namespace Validators.Validators.OrderItems 
{
    public class GetAllOrdersItemByIdValidator : AbstractValidator<GetOrdersItemsQuery>
    {
        public GetAllOrdersItemByIdValidator()
        {
            
        }
    }
}
