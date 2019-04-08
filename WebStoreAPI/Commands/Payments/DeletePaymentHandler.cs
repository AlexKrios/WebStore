using System;
using System.Threading;
using System.Threading.Tasks;
using DataLibrary;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace WebStoreAPI.Commands.Payments
{
    public class DeletePaymentHandler : IRequestHandler<DeletePaymentCommand, DeletePaymentCommand>
    {
        private readonly WebStoreContext _context;

        public DeletePaymentHandler(WebStoreContext context)
        {
            _context = context;
        }

        public async Task<DeletePaymentCommand> Handle(DeletePaymentCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var payment = await _context.Payments.FirstOrDefaultAsync(x => x.Id == command.Id, cancellationToken);

                if (payment == null) return null;

                _context.Payments.Remove(payment);
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
