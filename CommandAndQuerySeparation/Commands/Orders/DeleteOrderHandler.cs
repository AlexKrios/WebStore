using System;
using System.Threading;
using System.Threading.Tasks;
using DataLibrary;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CommandAndQuerySeparation.Commands.Orders
{
    public class DeleteCityHandler : IRequestHandler<DeleteOrderCommand, DeleteOrderCommand>
    {
        private readonly WebStoreContext _context;

        public DeleteCityHandler(WebStoreContext context)
        {
            _context = context;
        }

        public async Task<DeleteOrderCommand> Handle(DeleteOrderCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var order = await _context.Orders.FirstOrDefaultAsync(x => x.Id == command.Id, cancellationToken);

                if (order == null) return null;

                _context.Orders.Remove(order);
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
