using CQS.Queries.Manufacturers;
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

namespace CQS.Handlers.Manufacturers
{
    public class GetManufacturersHandler : IRequestHandler<GetManufacturersQuery, IEnumerable<Manufacturer>>
    {
        private readonly WebStoreContext _context;
        private readonly ILogger<GetManufacturersHandler> _logger;

        public GetManufacturersHandler(WebStoreContext context, ILogger<GetManufacturersHandler> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<IEnumerable<Manufacturer>> Handle(GetManufacturersQuery query, CancellationToken cancellationToken)
        {
            try
            {
                return await _context.Manufacturers.Where(query.Specification).ToListAsync(cancellationToken);
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"GET MANUFACTURERS, HANDLER - {e.Message}");
                throw;
            }
        }
    }
}