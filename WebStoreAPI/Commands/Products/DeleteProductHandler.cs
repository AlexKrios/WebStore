using WebStoreAPI.Models;

namespace WebStoreAPI.Commands.Products
{
    public class DeleteProductHandler : ICommandHandler<DeleteProduct>
    {
        private readonly WebStoreContext _context;
        public DeleteProductHandler(WebStoreContext context)
        {
            _context = context;
        }

        public void Execute(DeleteProduct delete)
        {
            _context.Products.Remove(delete.Id);
            _context.SaveChanges();
        }
    }
}