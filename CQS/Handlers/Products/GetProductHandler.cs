using CQS.Queries.Products;
using DataLibrary;
using DataLibrary.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CQS.Handlers.Products
{
    public class GetProductHandler : IRequestHandler<GetProductQuery, Product>
    {
        private readonly WebStoreContext _context;
        private readonly ILogger<GetProductHandler> _logger;

        public GetProductHandler(WebStoreContext context, ILogger<GetProductHandler> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<Product> Handle(GetProductQuery query, CancellationToken cancellationToken)
        {
            try
            {
                return await _context.Products.FirstOrDefaultAsync(x => x.Id == query.Id, cancellationToken);
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"GET PRODUCT, HANDLER - {e.Message}");
                throw;
            }
        }
    }
}
