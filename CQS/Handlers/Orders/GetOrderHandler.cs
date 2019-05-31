using CQS.Queries.Orders;
using DataLibrary;
using DataLibrary.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CQS.Handlers.Orders
{
    public class GetOrderHandler : IRequestHandler<GetOrderQuery, Order>
    {
        private readonly WebStoreContext _context;
        private readonly ILogger<GetOrderHandler> _logger;

        public GetOrderHandler(WebStoreContext context, ILogger<GetOrderHandler> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<Order> Handle(GetOrderQuery query, CancellationToken cancellationToken)
        {
            try
            {
                return await _context.Orders.FirstOrDefaultAsync(x => x.Id == query.Id, cancellationToken);
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"GET ORDER, HANDLER - {e.Message}");
                throw;
            }
        }
    }
}
