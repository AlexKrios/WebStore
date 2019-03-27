using WebStoreAPI.Models;

namespace WebStoreAPI.Commands.Products
{
    //Delete request command for product
    public class DeleteProductCommand : ICommand
    {
        public Product Id { get; }

        public DeleteProductCommand(Product id)
        {
            Id = id;
        }
    }
}
