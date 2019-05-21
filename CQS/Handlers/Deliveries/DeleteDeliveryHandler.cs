using System;
using System.Threading;
using System.Threading.Tasks;
using CQS.Commands.Deliveries;
using DataLibrary;
using DataLibrary.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CQS.Handlers.Deliveries
{
    public class DeleteDeliveryHandler : IRequestHandler<DeleteDeliveryCommand, Delivery>
    {
        private readonly WebStoreContext _context;

        public DeleteDeliveryHandler(WebStoreContext context)
        {
            _context = context;
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
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
