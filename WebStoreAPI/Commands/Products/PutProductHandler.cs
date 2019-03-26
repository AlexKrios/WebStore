using WebStoreAPI.Models;

namespace WebStoreAPI.Commands.Products
{
    //Change command for product model
    public class PutProductHandler : PutProduct<Product>
    {
        private readonly WebStoreContext _context;
        public PutProductHandler(WebStoreContext context)
        {
            _context = context;
        }

        public override void Execute(Product obj)
        {
            _context.Update(obj);
            _context.SaveChanges();
        }
    }
}
