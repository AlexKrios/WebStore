using CQS.Commands.Manufacturers;
using DataLibrary;
using DataLibrary.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CQS.Handlers.Manufacturers
{
    public class DeleteCityHandler : IRequestHandler<DeleteManufacturerCommand, Manufacturer>
    {
        private readonly WebStoreContext _context;
        private readonly ILogger<DeleteCityHandler> _logger;

        public DeleteCityHandler(WebStoreContext context, ILogger<DeleteCityHandler> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<Manufacturer> Handle(DeleteManufacturerCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var manufacturer = await _context.Manufacturers.FirstOrDefaultAsync(x => x.Id == command.Id, cancellationToken);

                if (manufacturer == null) return null;

                _context.Manufacturers.Remove(manufacturer);
                await _context.SaveChangesAsync(cancellationToken);
                return manufacturer;
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"DELETE MANUFACTURER, HANDLER - {e.Message}");
                throw;
            }
        }
    }
}
