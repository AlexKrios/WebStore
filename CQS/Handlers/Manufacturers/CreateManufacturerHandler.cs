using AutoMapper;
using CQS.Commands.Manufacturers;
using DataLibrary;
using DataLibrary.Entities;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CQS.Handlers.Manufacturers
{
    public class CreateManufacturerHandler : IRequestHandler<CreateManufacturerCommand, Manufacturer>
    {
        private readonly WebStoreContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateManufacturerHandler> _logger;

        public CreateManufacturerHandler(WebStoreContext context, IMapper mapper, ILogger<CreateManufacturerHandler> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Manufacturer> Handle(CreateManufacturerCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var manufacturer = _mapper.Map<Manufacturer>(command);

                await _context.Manufacturers.AddAsync(manufacturer, cancellationToken);
                await _context.SaveChangesAsync(cancellationToken);
                return manufacturer;
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"CREATE MANUFACTURER, HANDLER - {e.Message}");
                throw;
            }
        }
    }
}
