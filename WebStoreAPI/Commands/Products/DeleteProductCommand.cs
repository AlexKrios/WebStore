using MediatR;
using WebStoreAPI.Models;

namespace WebStoreAPI.Commands.Products
{
    //Delete request command for product
    public class DeleteProductCommand : IRequest<Product>
    {
        public Product Product { get; }

        public DeleteProductCommand(Product product)
        {
            Product = product;
        }
    }
}
