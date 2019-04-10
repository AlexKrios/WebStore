using System;
using System.Threading;
using System.Threading.Tasks;
using DataLibrary;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CommandAndQuerySeparation.Commands.OrderItems
{
    public class DeleteOrderItemsHandler : IRequestHandler<DeleteOrderItemsCommand, DeleteOrderItemsCommand>
    {
        private readonly WebStoreContext _context;

        public DeleteOrderItemsHandler(WebStoreContext context)
        {
            _context = context;
        }

        public async Task<DeleteOrderItemsCommand> Handle(DeleteOrderItemsCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var orderItems = await _context.OrderItems.FirstOrDefaultAsync(x => x.Id == command.Id, cancellationToken);

                if (orderItems == null) return null;

                _context.OrderItems.Remove(orderItems);
                await _context.SaveChangesAsync(cancellationToken);
                return command;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
