using CQS.Commands.Orders;
using DataLibrary;
using DataLibrary.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CQS.Handlers.Orders
{
    public class DeleteCityHandler : IRequestHandler<DeleteOrderCommand, Order>
    {
        private readonly WebStoreContext _context;
        private readonly ILogger<DeleteCityHandler> _logger;

        public DeleteCityHandler(WebStoreContext context, ILogger<DeleteCityHandler> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<Order> Handle(DeleteOrderCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var order = await _context.Orders.FirstOrDefaultAsync(x => x.Id == command.Id, cancellationToken);

                if (order == null) return null;

                _context.Orders.Remove(order);
                await _context.SaveChangesAsync(cancellationToken);
                return order;
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"DELETE ORDER, HANDLER - {e.Message}");
                throw;
            }
        }
    }
}
