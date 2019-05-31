using CQS.Commands.Products;
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
    public class DeleteProductHandler : IRequestHandler<DeleteProductCommand, Product>
    {
        private readonly WebStoreContext _context;
        private readonly ILogger<DeleteProductHandler> _logger;

        public DeleteProductHandler(WebStoreContext context, ILogger<DeleteProductHandler> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<Product> Handle(DeleteProductCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var product = await _context.Products.FirstOrDefaultAsync(x => x.Id == command.Id, cancellationToken);

                if (product == null) return null;

                _context.Products.Remove(product);
                await _context.SaveChangesAsync(cancellationToken);
                return product;
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"DELETE PRODUCT, HANDLER - {e.Message}");
                throw;
            }            
        }
    }
}