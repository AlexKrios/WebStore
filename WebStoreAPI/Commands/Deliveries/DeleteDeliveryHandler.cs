using System;
using System.Threading;
using System.Threading.Tasks;
using DataLibrary;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace WebStoreAPI.Commands.Deliveries
{
    public class DeleteDeliveryHandler : IRequestHandler<DeleteDeliveryCommand, DeleteDeliveryCommand>
    {
        private readonly WebStoreContext _context;

        public DeleteDeliveryHandler(WebStoreContext context)
        {
            _context = context;
        }

        public async Task<DeleteDeliveryCommand> Handle(DeleteDeliveryCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var delivery = await _context.Users.FirstOrDefaultAsync(x => x.Id == command.Id, cancellationToken);

                if (delivery == null) return null;

                _context.Users.Remove(delivery);
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
