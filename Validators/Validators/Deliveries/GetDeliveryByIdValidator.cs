using CQS.Queries.Deliveries;
using FluentValidation;

namespace Validators.Validators.Deliveries 
{
    public class GetDeliveryByIdValidator : AbstractValidator<GetDeliveryQuery>
    {
        public GetDeliveryByIdValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("Id must be entered");
        }
    }
}
