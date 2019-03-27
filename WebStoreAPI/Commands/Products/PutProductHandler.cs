using System.Threading.Tasks;
using WebStoreAPI.Models;

namespace WebStoreAPI.Commands.Products
{
    //Put request handler for product
    public class PutProductHandler : ICommandHandler<PutProductCommand>
    {
        private readonly WebStoreContext _context;

        public PutProductHandler(WebStoreContext context)
        {
            _context = context;
        }

        public async Task Execute(PutProductCommand command)
        {
            _context.Update(command.Id);
            await _context.SaveChangesAsync();
        }
    }
}
