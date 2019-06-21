using CQS.Queries.OrderItems;
using DataLibrary;
using DataLibrary.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
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
        private readonly IConfiguration _config;

        public GetOrdersItemsHandler(WebStoreContext context, ILogger<GetOrdersItemsHandler> logger, IConfiguration config)
        {
            _context = context;
            _logger = logger;
            _config = config;
        }

        public async Task<IEnumerable<OrderItem>> Handle(GetOrdersItemsQuery query, CancellationToken cancellationToken)
        {
            try
            {
                if (query.Skip == null)
                {
                    query.Skip = Convert.ToInt32(_config["Pagination:Skip"]);
                }

                if (query.Take == null)
                {
                    query.Take = Convert.ToInt32(_config["Pagination:Take"]);
                }

                return await _context.OrderItems.Where(query.Specification)
                    .OrderBy(x => x.Id).Skip((int)query.Skip).Take((int)query.Take).ToListAsync(cancellationToken);
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"GET ORDERSITEMS, HANDLER - {e.Message}");
                throw;
            }
        }
    }
}