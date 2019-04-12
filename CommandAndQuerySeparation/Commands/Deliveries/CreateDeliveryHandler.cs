using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DataLibrary;
using DataLibrary.Entities;
using MediatR;

namespace CommandAndQuerySeparation.Commands.Deliveries
{
    public class CreateDeliveryHandler : IRequestHandler<CreateDeliveryCommand, Delivery>
    {
        private readonly WebStoreContext _context;
        private readonly IMapper _mapper;

        public CreateDeliveryHandler(WebStoreContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Delivery> Handle(CreateDeliveryCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var delivery = _mapper.Map<Delivery>(command);

                await _context.Deliveries.AddAsync(delivery, cancellationToken);
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
