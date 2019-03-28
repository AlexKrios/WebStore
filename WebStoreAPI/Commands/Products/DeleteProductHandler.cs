using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
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
            var product = await _context.Products.FirstOrDefaultAsync(x => x.Id == command.Id, cancellationToken: cancellationToken);

            _context.Products.Remove(product);
            await _context.SaveChangesAsync(cancellationToken);
            return product;
        }
    }
}