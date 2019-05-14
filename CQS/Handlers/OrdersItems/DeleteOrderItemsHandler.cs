using System;
using System.Threading;
using System.Threading.Tasks;
using CQS.Commands.OrdersItems;
using DataLibrary;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CQS.Handlers.OrdersItems
{
    public class DeleteOrderItemsHandler : IRequestHandler<DeleteOrderItemsCommand, DataLibrary.Entities.OrderItems>
    {
        private readonly WebStoreContext _context;

        public DeleteOrderItemsHandler(WebStoreContext context)
        {
            _context = context;
        }

        public async Task<DataLibrary.Entities.OrderItems> Handle(DeleteOrderItemsCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var orderItems = await _context.OrdersItems.FirstOrDefaultAsync(x => x.Id == command.Id, cancellationToken);

                if (orderItems == null) return null;

                _context.OrdersItems.Remove(orderItems);
                await _context.SaveChangesAsync(cancellationToken);
                return orderItems;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
