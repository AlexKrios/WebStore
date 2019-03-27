using WebStoreAPI.Models;

namespace WebStoreAPI.Commands.Products
{
    //Post request command for product
    public class PostProductCommand : ICommand
    {
        public Product Id { get; }

        public PostProductCommand(Product id)
        {
            Id = id;
        }
    }
}
