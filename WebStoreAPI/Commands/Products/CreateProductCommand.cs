using MediatR;
using WebStoreAPI.Models;

namespace WebStoreAPI.Commands.Products
{
    //Post request command for product
    public class CreateProductCommand : IRequest<Product>
    {
        public Product Product { get; }

        public CreateProductCommand(Product product)
        {
            Product = product;
        }
    }
}
