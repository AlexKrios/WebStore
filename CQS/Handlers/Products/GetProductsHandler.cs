using CQS.Queries.Products;
using DataLibrary;
using DataLibrary.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CQS.Handlers.Products
{
    public class GetProductsHandler : IRequestHandler<GetProductsQuery, IEnumerable<Product>>
    {
        private readonly WebStoreContext _context;
        private readonly ILogger<GetProductsHandler> _logger;

        public GetProductsHandler(WebStoreContext context, ILogger<GetProductsHandler> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<IEnumerable<Product>> Handle(GetProductsQuery query, CancellationToken cancellationToken)
        {
            try
            {
                return await _context.Products.Where(query.Specification)
                    .OrderBy(x => x.Id).Skip(query.Skip).Take(query.Take).ToListAsync(cancellationToken);
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"GET PRODUCTS, HANDLER - {e.Message}");
                throw;
            }
        }
    }
}