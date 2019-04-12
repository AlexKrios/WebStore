using System;
using System.Threading;
using System.Threading.Tasks;
using DataLibrary;
using DataLibrary.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CommandAndQuerySeparation.Commands.Payments
{
    public class DeletePaymentHandler : IRequestHandler<DeletePaymentCommand, Payment>
    {
        private readonly WebStoreContext _context;

        public DeletePaymentHandler(WebStoreContext context)
        {
            _context = context;
        }

        public async Task<Payment> Handle(DeletePaymentCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var payment = await _context.Payments.FirstOrDefaultAsync(x => x.Id == command.Id, cancellationToken);

                if (payment == null) return null;

                _context.Payments.Remove(payment);
                await _context.SaveChangesAsync(cancellationToken);
                return payment;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
