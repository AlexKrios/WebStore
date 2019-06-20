using CQS.Queries.Deliveries;
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

namespace CQS.Handlers.Deliveries
{
    public class GetDeliveriesHandler : IRequestHandler<GetDeliveriesQuery, IEnumerable<Delivery>>
    {
        private readonly WebStoreContext _context;
        private readonly ILogger<GetDeliveriesHandler> _logger;

        public GetDeliveriesHandler(WebStoreContext context, ILogger<GetDeliveriesHandler> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<IEnumerable<Delivery>> Handle(GetDeliveriesQuery query, CancellationToken cancellationToken)
        {
            try
            {
                return await _context.Deliveries.Where(query.Specification)
                    .OrderBy(x => x.Id).Skip(query.Skip).Take(query.Take).ToListAsync(cancellationToken);
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"GET DELIVERIES, HANDLER - {e.Message}");
                throw;
            }
        }
    }
}