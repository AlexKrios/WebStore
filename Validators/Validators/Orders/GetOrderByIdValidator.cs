using CommandAndQuerySeparation.Queries.Orders;
using FluentValidation;

namespace Validators.Validators.Orders 
{
    public class GetOrderByIdValidator : AbstractValidator<GetOrderByIdQuery>
    {
        public GetOrderByIdValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("Id must be entered");
        }
    }
}
