using MediatR;
using WebStoreAPI.Models;

namespace WebStoreAPI.Commands.Products
{
    //Post request command for product
    public class PostProductCommand : IRequest<Product>
    {
        public Product Product { get; }

        public PostProductCommand(Product product)
        {
            Product = product;
        }
    }
}
