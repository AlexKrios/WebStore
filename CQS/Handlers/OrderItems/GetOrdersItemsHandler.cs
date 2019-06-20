using CQS.Queries.OrderItems;
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

namespace CQS.Handlers.OrderItems
{
    public class GetOrdersItemsHandler : IRequestHandler<GetOrdersItemsQuery, IEnumerable<OrderItem>>
    {
        private readonly WebStoreContext _context;
        private readonly ILogger<GetOrdersItemsHandler> _logger;

        public GetOrdersItemsHandler(WebStoreContext context, ILogger<GetOrdersItemsHandler> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<IEnumerable<OrderItem>> Handle(GetOrdersItemsQuery query, CancellationToken cancellationToken)
        {
            try
            {
                return await _context.OrderItems.Where(query.Specification)
                    .OrderBy(x => x.Id).Skip(query.Skip).Take(query.Take).ToListAsync(cancellationToken);
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"GET ORDERSITEMS, HANDLER - {e.Message}");
                throw;
            }
        }
    }
}