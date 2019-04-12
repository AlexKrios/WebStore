using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DataLibrary;
using DataLibrary.Entities;
using MediatR;

namespace CommandAndQuerySeparation.Commands.Payments
{
    public class UpdatePaymentHandler : IRequestHandler<UpdatePaymentCommand, Payment>
    {
        private readonly WebStoreContext _context;
        private readonly IMapper _mapper;

        public UpdatePaymentHandler(WebStoreContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Payment> Handle(UpdatePaymentCommand command, CancellationToken cancellationToken)
        {
            try
            {
                if (!_context.Payments.Any(x => x.Id == command.Id)) return null;

                var payment = _mapper.Map<Payment>(command);

                _context.Payments.Update(payment);
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