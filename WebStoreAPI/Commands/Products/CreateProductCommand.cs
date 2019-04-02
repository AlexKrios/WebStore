using MediatR;
using WebStoreAPI.Mapper;

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
