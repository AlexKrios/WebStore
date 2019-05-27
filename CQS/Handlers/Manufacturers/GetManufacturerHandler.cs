using CQS.Queries.Manufacturers;
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
    public class GetManufacturerHandler : IRequestHandler<GetManufacturerQuery, Manufacturer>
    {
        private readonly WebStoreContext _context;
        private readonly ILogger<GetManufacturerHandler> _logger;

        public GetManufacturerHandler(WebStoreContext context, ILogger<GetManufacturerHandler> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<Manufacturer> Handle(GetManufacturerQuery query, CancellationToken cancellationToken)
        {
            try
            {
                return await _context.Manufacturers.FirstOrDefaultAsync(x => x.Id == query.Id, cancellationToken);
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"GET MANUFACTURER, HANDLER - {e.Message}");
                throw;
            }
        }
    }
}
