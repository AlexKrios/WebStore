using FluentValidation;
using WebStoreAPI.Queries.Products;

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
