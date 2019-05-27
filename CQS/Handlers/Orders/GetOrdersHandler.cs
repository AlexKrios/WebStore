using CQS.Queries.Orders;
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

namespace CQS.Handlers.Orders
{
    public class GetOrdersHandler : IRequestHandler<GetOrdersQuery, IEnumerable<Order>>
    {
        private readonly WebStoreContext _context;
        private readonly ILogger<GetOrdersHandler> _logger;

        public GetOrdersHandler(WebStoreContext context, ILogger<GetOrdersHandler> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<IEnumerable<Order>> Handle(GetOrdersQuery query, CancellationToken cancellationToken)
        {
            try
            {
                return await _context.Orders.Where(query.Specification).ToListAsync(cancellationToken);
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"GET ORDERS, HANDLER - {e.Message}");
                throw;
            }
        }
    }
}