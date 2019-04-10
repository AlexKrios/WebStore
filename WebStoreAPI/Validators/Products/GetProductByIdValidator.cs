using CommandAndQuerySeparation.Queries.Products;
using FluentValidation;

namespace WebStoreAPI.Validators.Products 
{
    public class GetProductByIdValidator : AbstractValidator<GetProductByIdQuery>
    {
        public GetProductByIdValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("Input correct id");
        }
    }
}
