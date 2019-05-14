using FluentValidation;
using WebStoreAPI.Requests.Orders;

namespace Validators.Validators.Orders 
{
    public class GetOrderByIdValidator : AbstractValidator<GetOrderRequest>
    {
        public GetOrderByIdValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("Id must be entered");
        }
    }
}
