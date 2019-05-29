using CQS.Queries.Deliveries;
using DataLibrary;
using DataLibrary.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CQS.Handlers.Deliveries
{
    public class GetDeliveryHandler : IRequestHandler<GetDeliveryQuery, Delivery>
    {
        private readonly WebStoreContext _context;
        private readonly ILogger<GetDeliveryHandler> _logger;

        public GetDeliveryHandler(WebStoreContext context, ILogger<GetDeliveryHandler> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<Delivery> Handle(GetDeliveryQuery query, CancellationToken cancellationToken)
        {
            try
            {
                return await _context.Deliveries.FirstOrDefaultAsync(x => x.Id == query.Id, cancellationToken);
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"GET DELIVERY, HANDLER - {e.Message}");
                throw;
            }
        }
    }
}
