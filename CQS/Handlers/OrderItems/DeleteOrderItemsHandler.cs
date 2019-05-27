using CQS.Commands.OrderItems;
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
    public class DeleteOrderItemsHandler : IRequestHandler<DeleteOrderItemsCommand, OrderItem>
    {
        private readonly WebStoreContext _context;
        private readonly ILogger<DeleteOrderItemsHandler> _logger;

        public DeleteOrderItemsHandler(WebStoreContext context, ILogger<DeleteOrderItemsHandler> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<OrderItem> Handle(DeleteOrderItemsCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var orderItems = await _context.OrderItems.FirstOrDefaultAsync(x => x.Id == command.Id, cancellationToken);

                if (orderItems == null) return null;

                _context.OrderItems.Remove(orderItems);
                await _context.SaveChangesAsync(cancellationToken);
                return orderItems;
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"DELETE ORDERITEMS, HANDLER - {e.Message}");
                throw;
            }
        }
    }
}
