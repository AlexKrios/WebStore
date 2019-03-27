using WebStoreAPI.Models;

namespace WebStoreAPI.Commands.Products
{
    //Put request command for product
    public class PutProductCommand : ICommand
    {
        public Product User { get; }

        public PutProductCommand(Product user)
        {
            User = user;
        }
    }
}
