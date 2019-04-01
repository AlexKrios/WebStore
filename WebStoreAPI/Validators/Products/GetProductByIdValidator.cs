using FluentValidation;
using WebStoreAPI.Queries.Products;

namespace WebStoreAPI.Validators.Products 
{
    public class GetProductByIdValidator : AbstractValidator<GetProductByIdQuery>
    {
        public GetProductByIdValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Input correct id");
        }
    }
}
