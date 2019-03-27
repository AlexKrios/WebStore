using System.Threading;
using System.Threading.Tasks;
using MediatR;
using WebStoreAPI.Models;

namespace WebStoreAPI.Commands.Products
{
    //Delete request handler for product
    public class DeleteProductHandler : IRequestHandler<DeleteProductCommand, Product>
    {
        private readonly WebStoreContext _context;

        public DeleteProductHandler(WebStoreContext context)
        {
            _context = context;
        }

        public async Task<Product> Handle(DeleteProductCommand command, CancellationToken cancellationToken)
        {
            _context.Products.Remove(command.Product);
            await _context.SaveChangesAsync(cancellationToken);
            return command.Product;
        }
    }
}