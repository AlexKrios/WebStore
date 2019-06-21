using CQS.Queries.Payments;
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

namespace CQS.Handlers.Payments
{
    public class GetPaymentsHandler : IRequestHandler<GetPaymentsQuery, IEnumerable<Payment>>
    {
        private readonly WebStoreContext _context;
        private readonly ILogger<GetPaymentsHandler> _logger;
        private readonly IConfiguration _config;

        public GetPaymentsHandler(WebStoreContext context, ILogger<GetPaymentsHandler> logger, IConfiguration config)
        {
            _context = context;
            _logger = logger;
            _config = config;
        }

        public async Task<IEnumerable<Payment>> Handle(GetPaymentsQuery query, CancellationToken cancellationToken)
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

                return await _context.Payments.Where(query.Specification)
                    .OrderBy(x => x.Id).Skip((int)query.Skip).Take((int)query.Take).ToListAsync(cancellationToken);
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"GET PAYMENTS, HANDLER - {e.Message}");
                throw;
            }
        }
    }
}