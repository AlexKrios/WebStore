using System;
using System.Threading;
using System.Threading.Tasks;
using CQS.Commands.Orders;
using DataLibrary;
using DataLibrary.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CQS.Handlers.Orders
{
    public class DeleteCityHandler : IRequestHandler<DeleteOrderCommand, Order>
    {
        private readonly WebStoreContext _context;

        public DeleteCityHandler(WebStoreContext context)
        {
            _context = context;
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
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
