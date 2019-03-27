using System.Threading;
using System.Threading.Tasks;
using MediatR;
using WebStoreAPI.Models;

namespace WebStoreAPI.Commands.Products
{
    //Post request handler for product
    public class PostProductHandler : IRequestHandler<PostProductCommand, Product>
    {
        private readonly WebStoreContext _context;

        public PostProductHandler(WebStoreContext context)
        {
            _context = context;
        }

        public async Task<Product> Handle(PostProductCommand command, CancellationToken cancellationToken)
        {
            await _context.Products.AddAsync(command.Product, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return command.Product;
        }
    }
}
