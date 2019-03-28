using System.Threading;
using System.Threading.Tasks;
using MediatR;
using WebStoreAPI.Models;

namespace WebStoreAPI.Commands.Products
{
    //Put request handler for product
    public class UpdateProductHandler : IRequestHandler<UpdateProductCommand>
    {
        private readonly WebStoreContext _context;

        public UpdateProductHandler(WebStoreContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateProductCommand command, CancellationToken cancellationToken)
        {
            _context.Products.Update(command.User);
            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
