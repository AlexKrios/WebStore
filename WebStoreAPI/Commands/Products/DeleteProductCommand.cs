using WebStoreAPI.Models;

namespace WebStoreAPI.Commands.Products
{
    //Delete request command for product
    public class DeleteProductCommand : ICommand
    {
        public Product Product { get; }

        public DeleteProductCommand(Product product)
        {
            Product = product;
        }
    }
}
