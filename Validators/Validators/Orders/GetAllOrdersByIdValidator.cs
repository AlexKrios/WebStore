using CommandAndQuerySeparation.Queries.Orders;
using FluentValidation;

namespace Validators.Validators.Orders 
{
    public class GetAllOrdersByIdValidator : AbstractValidator<GetAllOrdersQuery>
    {
        public GetAllOrdersByIdValidator()
        {
            
        }
    }
}
