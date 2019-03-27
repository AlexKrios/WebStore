using System.Threading;
using System.Threading.Tasks;
using MediatR;
using WebStoreAPI.Models;

namespace WebStoreAPI.Commands.Products
{
    //Put request handler for product
    public class PutProductHandler : IRequestHandler<PutProductCommand, Product>
    {
        private readonly WebStoreContext _context;

        public PutProductHandler(WebStoreContext context)
        {
            _context = context;
        }

        public async Task<Product> Handle(PutProductCommand command, CancellationToken cancellationToken)
        {
            _context.Products.Update(command.User);
            await _context.SaveChangesAsync(cancellationToken);
            return command.User;
        }
    }
}
