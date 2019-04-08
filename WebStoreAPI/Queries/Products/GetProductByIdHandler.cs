using System.Threading;
using System.Threading.Tasks;
using DataLibrary;
using DataLibrary.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace WebStoreAPI.Queries.Products
{
    public class GetProductByIdHandler : IRequestHandler<GetProductByIdQuery, Product>
    {
        private readonly WebStoreContext _context;

        public GetProductByIdHandler(WebStoreContext context)
        {
            _context = context;
        }

        public async Task<Product> Handle(GetProductByIdQuery command, CancellationToken cancellationToken)
        {
            return await _context.Products.FirstOrDefaultAsync(x => x.Id == command.Id, cancellationToken);
        }
    }
}
