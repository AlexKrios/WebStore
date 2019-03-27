using MediatR;
using WebStoreAPI.Models;

namespace WebStoreAPI.Commands.Products
{
    //Put request command for product
    public class PutProductCommand : IRequest<Product>
    {
        public Product User { get; }

        public PutProductCommand(Product user)
        {
            User = user;
        }
    }
}
