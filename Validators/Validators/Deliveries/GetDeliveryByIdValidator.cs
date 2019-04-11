using CommandAndQuerySeparation.Queries.Deliveries;
using FluentValidation;

namespace Validators.Validators.Deliveries 
{
    public class GetDeliveryByIdValidator : AbstractValidator<GetDeliveryByIdQuery>
    {
        public GetDeliveryByIdValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("Id must be entered");
        }
    }
}
