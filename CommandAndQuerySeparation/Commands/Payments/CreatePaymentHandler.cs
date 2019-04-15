using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DataLibrary;
using DataLibrary.Entities;
using MediatR;

namespace CommandAndQuerySeparation.Commands.Payments
{
    public class CreatePaymentHandler : IRequestHandler<CreatePaymentCommand, Payment>
    {
        private readonly WebStoreContext _context;
        private readonly IMapper _mapper;

        public CreatePaymentHandler(WebStoreContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Payment> Handle(CreatePaymentCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var payment = _mapper.Map<Payment>(command);

                await _context.Payments.AddAsync(payment, cancellationToken);
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
