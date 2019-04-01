using MediatR;
using WebStoreAPI.Models;

namespace WebStoreAPI.Commands.Products
{
    //Put request command for product
    public class UpdateProductCommand : IRequest
    {
        public Product Product { get; }

        public UpdateProductCommand(Product product)
        {
            Product = product;
        }
    }
}
