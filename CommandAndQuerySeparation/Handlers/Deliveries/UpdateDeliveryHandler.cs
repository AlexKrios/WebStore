using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using CQS.Commands.Deliveries;
using DataLibrary;
using DataLibrary.Entities;
using MediatR;

namespace CQS.Handlers.Deliveries
{
    public class UpdateDeliveryHandler : IRequestHandler<UpdateDeliveryCommand, Delivery>
    {
        private readonly WebStoreContext _context;
        private readonly IMapper _mapper;

        public UpdateDeliveryHandler(WebStoreContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Delivery> Handle(UpdateDeliveryCommand command, CancellationToken cancellationToken)
        {
            try
            {
                if (!_context.Deliveries.Any(x => x.Id == command.Id)) return null;

                var delivery = _mapper.Map<Delivery>(command);

                _context.Deliveries.Update(delivery);
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