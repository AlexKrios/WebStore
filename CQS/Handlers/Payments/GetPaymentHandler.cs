using CQS.Queries.Payments;
using DataLibrary;
using DataLibrary.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CQS.Handlers.Payments
{
    public class GetPaymentHandler : IRequestHandler<GetPaymentQuery, Payment>
    {
        private readonly WebStoreContext _context;
        private readonly ILogger<GetPaymentHandler> _logger;

        public GetPaymentHandler(WebStoreContext context, ILogger<GetPaymentHandler> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<Payment> Handle(GetPaymentQuery query, CancellationToken cancellationToken)
        {
            try
            {
                return await _context.Payments.FirstOrDefaultAsync(x => x.Id == query.Id, cancellationToken);
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"GET PAYMENT, HANDLER - {e.Message}");
                throw;
            }
        }
    }
}
