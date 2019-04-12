using System;
using System.Threading;
using System.Threading.Tasks;
using DataLibrary;
using DataLibrary.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CommandAndQuerySeparation.Queries.Products
{
    public class GetProductHandler : IRequestHandler<GetProductQuery, Product>
    {
        private readonly WebStoreContext _context;

        public GetProductHandler(WebStoreContext context)
        {
            _context = context;
        }

        public async Task<Product> Handle(GetProductQuery query, CancellationToken cancellationToken)
        {
            try
            {
                return await _context.Products.FirstOrDefaultAsync(x => x.Id == query.Id, cancellationToken);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
