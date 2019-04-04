using FluentValidation;
using WebStoreAPI.Queries.Products;

namespace WebStoreAPI.Validators.Products
{
    public class GetProductByTypeValidator : AbstractValidator<GetProductsByTypeQuery>
    {
        public GetProductByTypeValidator()
        {
            RuleFor(x => x.Type)
                .NotEmpty()
                .WithMessage("Input correct type");
        }
    }
}
