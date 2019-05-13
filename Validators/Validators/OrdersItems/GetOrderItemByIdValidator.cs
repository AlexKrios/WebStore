using CQS.Queries.OrdersItems;
using FluentValidation;

namespace Validators.Validators.OrdersItems 
{
    public class GetOrderItemByIdValidator : AbstractValidator<GetOrderItemsQuery>
    {
        public GetOrderItemByIdValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("Id must be entered");
        }
    }
}
