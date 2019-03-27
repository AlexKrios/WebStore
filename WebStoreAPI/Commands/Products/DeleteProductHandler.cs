using System.Threading.Tasks;
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

        public async Task Execute(DeleteProductCommand command)
        {
            _context.Products.Remove(command.Id);
            await _context.SaveChangesAsync();
        }
    }
}