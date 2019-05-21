using FluentValidation;
using WebStoreAPI.Requests.Deliveries;

namespace Validators.Validators.Deliveries 
{
    public class GetDeliveryByIdValidator : AbstractValidator<GetDeliveryRequest>
    {
        public GetDeliveryByIdValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("Id must be entered");
        }
    }
}
