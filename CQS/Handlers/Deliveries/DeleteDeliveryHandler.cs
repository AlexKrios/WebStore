using CQS.Commands.Deliveries;
using DataLibrary;
using DataLibrary.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CQS.Handlers.Deliveries
{
    public class DeleteDeliveryHandler : IRequestHandler<DeleteDeliveryCommand, Delivery>
    {
        private readonly WebStoreContext _context;
        private readonly ILogger<DeleteDeliveryHandler> _logger;

        public DeleteDeliveryHandler(WebStoreContext context, ILogger<DeleteDeliveryHandler> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<Delivery> Handle(DeleteDeliveryCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var delivery = await _context.Deliveries.FirstOrDefaultAsync(x => x.Id == command.Id, cancellationToken);

                if (delivery == null) return null;

                _context.Deliveries.Remove(delivery);
                await _context.SaveChangesAsync(cancellationToken);
                return delivery;
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"DELETE DELIVERY, HANDLER - {e.Message}");
                throw;
            }
        }
    }
}
