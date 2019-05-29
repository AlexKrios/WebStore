using CQS.Queries.Payments;
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

namespace CQS.Handlers.Payments
{
    public class GetPaymentsHandler : IRequestHandler<GetPaymentsQuery, IEnumerable<Payment>>
    {
        private readonly WebStoreContext _context;
        private readonly ILogger<GetPaymentsHandler> _logger;

        public GetPaymentsHandler(WebStoreContext context, ILogger<GetPaymentsHandler> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<IEnumerable<Payment>> Handle(GetPaymentsQuery query, CancellationToken cancellationToken)
        {
            try
            {
                return await _context.Payments.Where(query.Specification).ToListAsync(cancellationToken);
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"GET PAYMENTS, HANDLER - {e.Message}");
                throw;
            }
        }
    }
}