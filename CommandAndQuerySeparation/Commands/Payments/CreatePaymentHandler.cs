using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DataLibrary;
using DataLibrary.Entities;
using MediatR;

namespace CommandAndQuerySeparation.Commands.Payments
{
    public class CreatePaymentHandler : IRequestHandler<CreatePaymentCommand, CreatePaymentCommand>
    {
        private readonly WebStoreContext _context;
        private readonly IMapper _mapper;

        public CreatePaymentHandler(WebStoreContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CreatePaymentCommand> Handle(CreatePaymentCommand command, CancellationToken cancellationToken)
        {
            try
            {
                await _context.Payments.AddAsync(_mapper.Map<Payment>(command), cancellationToken);
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
