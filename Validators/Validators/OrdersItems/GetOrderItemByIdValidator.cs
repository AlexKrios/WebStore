using FluentValidation;
using WebStoreAPI.Requests.OrdersItems;

namespace Validators.Validators.OrdersItems 
{
    public class GetOrderItemByIdValidator : AbstractValidator<GetOrderItemsRequest>
    {
        public GetOrderItemByIdValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("Id must be entered");
        }
    }
}
