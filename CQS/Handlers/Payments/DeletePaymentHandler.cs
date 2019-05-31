using CQS.Commands.Payments;
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
    public class DeletePaymentHandler : IRequestHandler<DeletePaymentCommand, Payment>
    {
        private readonly WebStoreContext _context;
        private readonly ILogger<DeletePaymentHandler> _logger;

        public DeletePaymentHandler(WebStoreContext context, ILogger<DeletePaymentHandler> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<Payment> Handle(DeletePaymentCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var payment = await _context.Payments.FirstOrDefaultAsync(x => x.Id == command.Id, cancellationToken);

                if (payment == null) return null;

                _context.Payments.Remove(payment);
                await _context.SaveChangesAsync(cancellationToken);
                return payment;
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"DELETE PAYMENT, HANDLER - {e.Message}");
                throw;
            }
        }
    }
}
