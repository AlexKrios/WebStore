using FluentValidation;
using WebStoreAPI.Requests.Products;

namespace Validators.Validators.Products 
{
    public class GetAllProductsByIdValidator : AbstractValidator<GetProductsRequest>
    {
        public GetAllProductsByIdValidator()
        {
            
        }
    }
}
