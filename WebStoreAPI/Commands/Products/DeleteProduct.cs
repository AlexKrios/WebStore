using WebStoreAPI.Models;

namespace WebStoreAPI.Commands.Products
{
    public class DeleteProduct : ICommandTag
    {
        public Product Id { get; }
        public DeleteProduct(Product id)
        {
            Id = id;
        }
    }
}
