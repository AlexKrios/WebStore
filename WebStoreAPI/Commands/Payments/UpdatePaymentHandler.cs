using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DataLibrary;
using DataLibrary.Entities;
using MediatR;

namespace WebStoreAPI.Commands.Payments
{
    public class UpdatePaymentHandler : IRequestHandler<UpdatePaymentCommand, UpdatePaymentCommand>
    {
        private readonly WebStoreContext _context;
        private readonly IMapper _mapper;

        public UpdatePaymentHandler(WebStoreContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<UpdatePaymentCommand> Handle(UpdatePaymentCommand command, CancellationToken cancellationToken)
        {
            try
            {
                if (!_context.Payments.Any(x => x.Id == command.Id)) return null;

                _context.Payments.Update(_mapper.Map<Payment>(command));
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