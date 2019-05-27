using AutoMapper;
using CQS.Commands.Products;
using DataLibrary;
using DataLibrary.Entities;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CQS.Handlers.Products
{
    public class UpdateProductHandler : IRequestHandler<UpdateProductCommand, Product>
    {
        private readonly WebStoreContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateProductHandler> _logger;

        public UpdateProductHandler(WebStoreContext context, IMapper mapper, ILogger<UpdateProductHandler> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Product> Handle(UpdateProductCommand command, CancellationToken cancellationToken)
        {
            try
            {
                if (!_context.Products.Any(x => x.Id == command.Id)) return null;

                var product = _mapper.Map<Product>(command);

                _context.Products.Update(product);
                await _context.SaveChangesAsync(cancellationToken);
                return product;
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"UPDATE PRODUCT, HANDLER - {e.Message}");
                throw;
            }
        }
    }
}