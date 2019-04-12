using CommandAndQuerySeparation.Queries.Products;
using FluentValidation;

namespace Validators.Validators.Products 
{
    public class GetProductByIdValidator : AbstractValidator<GetProductQuery>
    {
        public GetProductByIdValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("Id must be entered");
        }
    }
}
