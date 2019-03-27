using WebStoreAPI.Models;

namespace WebStoreAPI.Commands.Products
{
    //Delete request handler for product
    public class DeleteProductHandler : ICommandHandler<DeleteProductCommand>
    {
        private readonly WebStoreContext _context;

        public DeleteProductHandler(WebStoreContext context)
        {
            _context = context;
        }

        public void Execute(DeleteProductCommand command)
        {
            _context.Products.Remove(command.Id);
            _context.SaveChanges();
        }
    }
}