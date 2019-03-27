using WebStoreAPI.Models;

namespace WebStoreAPI.Commands.Products
{
    //Put request command for product
    public class PutProductCommand : ICommand
    {
        public Product Id { get; }

        public PutProductCommand(Product id)
        {
            Id = id;
        }
    }
}
