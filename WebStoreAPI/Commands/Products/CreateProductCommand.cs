using MediatR;
using WebStoreAPI.Models;

namespace WebStoreAPI.Commands.Products
{
    //Post request command for product
    public class CreateProductCommand : IRequest<ProductDto>
    {

        public ProductDto ProductDto { get; }

        public CreateProductCommand(ProductDto productDto)
        {
            ProductDto = productDto;
        }
    }
}
