using WebStoreAPI.Models;

namespace WebStoreAPI.Commands.Products
{
    public class PostProductHandler : Command<Product>
    {
        private readonly WebStoreContext _context;
        public PostProductHandler(WebStoreContext context)
        {
            _context = context;
        }

        public override void Execute(Product obj)
        {
            _context.Products.Add(obj);
            _context.SaveChanges();
        }
    }
}
