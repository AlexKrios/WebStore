using AutoMapper;
using CQS.Commands.Manufacturers;
using DataLibrary;
using DataLibrary.Entities;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CQS.Handlers.Manufacturers
{
    public class UpdateManufacturerHandler : IRequestHandler<UpdateManufacturerCommand, Manufacturer>
    {
        private readonly WebStoreContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateManufacturerHandler> _logger;

        public UpdateManufacturerHandler(WebStoreContext context, IMapper mapper, ILogger<UpdateManufacturerHandler> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Manufacturer> Handle(UpdateManufacturerCommand command, CancellationToken cancellationToken)
        {
            try
            {
                if (!_context.Manufacturers.Any(x => x.Id == command.Id)) return null;

                var manufacturer = _mapper.Map<Manufacturer>(command);

                _context.Manufacturers.Update(manufacturer);
                await _context.SaveChangesAsync(cancellationToken);
                return manufacturer;
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"UPDATE MANUFACTURER, HANDLER - {e.Message}");
                throw;
            }
        }
    }
}