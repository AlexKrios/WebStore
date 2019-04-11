using CommandAndQuerySeparation.Queries.Products;
using FluentValidation;

namespace Validators.Validators.Products 
{
    public class GetAllProductsByIdValidator : AbstractValidator<GetAllProductsQuery>
    {
        public GetAllProductsByIdValidator()
        {
            
        }
    }
}
