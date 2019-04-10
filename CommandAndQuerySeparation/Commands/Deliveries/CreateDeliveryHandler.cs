using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DataLibrary;
using DataLibrary.Entities;
using MediatR;

namespace CommandAndQuerySeparation.Commands.Deliveries
{
    public class CreateDeliveryHandler : IRequestHandler<CreateDeliveryCommand, CreateDeliveryCommand>
    {
        private readonly WebStoreContext _context;
        private readonly IMapper _mapper;

        public CreateDeliveryHandler(WebStoreContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CreateDeliveryCommand> Handle(CreateDeliveryCommand command, CancellationToken cancellationToken)
        {
            try
            {
                await _context.Deliveries.AddAsync(_mapper.Map<Delivery>(command), cancellationToken);
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
