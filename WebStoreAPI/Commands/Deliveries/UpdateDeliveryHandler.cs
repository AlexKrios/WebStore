using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DataLibrary;
using DataLibrary.Entities;
using MediatR;

namespace WebStoreAPI.Commands.Deliveries
{
    public class UpdateDeliveryHandler : IRequestHandler<UpdateDeliveryCommand, UpdateDeliveryCommand>
    {
        private readonly WebStoreContext _context;
        private readonly IMapper _mapper;

        public UpdateDeliveryHandler(WebStoreContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<UpdateDeliveryCommand> Handle(UpdateDeliveryCommand command, CancellationToken cancellationToken)
        {
            try
            {
                if (!_context.Deliveries.Any(x => x.Id == command.Id)) return null;

                _context.Deliveries.Update(_mapper.Map<Delivery>(command));
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