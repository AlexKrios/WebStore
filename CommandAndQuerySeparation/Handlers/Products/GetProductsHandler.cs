using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CQS.Queries.Products;
using DataLibrary;
using DataLibrary.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CQS.Handlers.Products
{
    public class GetProductsHandler : IRequestHandler<GetProductsQuery, IEnumerable<Product>>
    {
        private readonly WebStoreContext _context;

        public GetProductsHandler(WebStoreContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> Handle(GetProductsQuery query, CancellationToken cancellationToken)
        {
            try
            {
                return await _context.Products.ToListAsync(cancellationToken);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}