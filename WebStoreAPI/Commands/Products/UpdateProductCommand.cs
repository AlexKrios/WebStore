using MediatR;
using WebStoreAPI.Models;

namespace WebStoreAPI.Commands.Products
{
    //Put request command for product
    public class UpdateProductCommand : IRequest
    {
        public Product User { get; }

        public UpdateProductCommand(Product user)
        {
            User = user;
        }
    }
}
