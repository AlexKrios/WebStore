using CQS.Queries.Deliveries;
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

namespace CQS.Handlers.Deliveries
{
    public class GetDeliveriesHandler : IRequestHandler<GetDeliveriesQuery, IEnumerable<Delivery>>
    {
        private readonly WebStoreContext _context;
        private readonly ILogger<GetDeliveriesHandler> _logger;
        private readonly IConfiguration _config;

        public GetDeliveriesHandler(WebStoreContext context, ILogger<GetDeliveriesHandler> logger, IConfiguration config)
        {
            _context = context;
            _logger = logger;
            _config = config;
        }

        public async Task<IEnumerable<Delivery>> Handle(GetDeliveriesQuery query, CancellationToken cancellationToken)
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

                return await _context.Deliveries.Where(query.Specification)
                    .OrderBy(x => x.Id).Skip((int)query.Skip).Take((int)query.Take).ToListAsync(cancellationToken);
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"GET DELIVERIES, HANDLER - {e.Message}");
                throw;
            }
        }
    }
}