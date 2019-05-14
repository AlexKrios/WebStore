using FluentValidation;
using WebStoreAPI.Requests.Products;

namespace Validators.Validators.Products 
{
    public class GetProductByIdValidator : AbstractValidator<GetProductRequest>
    {
        public GetProductByIdValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("Id must be entered");
        }
    }
}
