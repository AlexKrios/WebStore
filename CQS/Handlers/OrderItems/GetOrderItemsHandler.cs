using CQS.Queries.OrderItems;
using DataLibrary;
using DataLibrary.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CQS.Handlers.OrderItems
{
    public class GetOrderItemsHandler : IRequestHandler<GetOrderItemsQuery, OrderItem>
    {
        private readonly WebStoreContext _context;
        private readonly ILogger<GetOrderItemsHandler> _logger;

        public GetOrderItemsHandler(WebStoreContext context, ILogger<GetOrderItemsHandler> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<OrderItem> Handle(GetOrderItemsQuery query, CancellationToken cancellationToken)
        {
            try
            {
                return await _context.OrderItems.FirstOrDefaultAsync(x => x.Id == query.Id, cancellationToken);
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"GET ORDERITEMS, HANDLER - {e.Message}");
                throw;
            }
        }
    }
}
