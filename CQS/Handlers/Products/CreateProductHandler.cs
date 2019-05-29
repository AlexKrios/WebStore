using AutoMapper;
using CQS.Commands.Products;
using DataLibrary;
using DataLibrary.Entities;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CQS.Handlers.Products
{
    public class CreateProductHandler : IRequestHandler<CreateProductCommand, Product>
    {
        private readonly WebStoreContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateProductHandler> _logger;

        public CreateProductHandler(WebStoreContext context, IMapper mapper, ILogger<CreateProductHandler> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Product> Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var product = _mapper.Map<Product>(command);

                await _context.Products.AddAsync(product, cancellationToken);
                await _context.SaveChangesAsync(cancellationToken);
                return product;
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"CREATE PRODUCT, HANDLER - {e.Message}");
                throw;
            }
        }
    }
}
