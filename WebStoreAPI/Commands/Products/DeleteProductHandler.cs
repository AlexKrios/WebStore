using WebStoreAPI.Models;

namespace WebStoreAPI.Commands.Products
{
    //Delete command for product model
    public class DeleteProductHandler : DeleteProduct<Product>
    {
        private readonly WebStoreContext _context;
        public DeleteProductHandler(WebStoreContext context)
        {
            _context = context;
        }

        public override void Execute(Product product)
        {
            _context.Products.Remove(product);
            _context.SaveChanges();
        }
    }
}