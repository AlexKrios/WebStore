using AutoMapper;
using CQS.Commands.Deliveries;
using DataLibrary;
using DataLibrary.Entities;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CQS.Handlers.Deliveries
{
    public class UpdateDeliveryHandler : IRequestHandler<UpdateDeliveryCommand, Delivery>
    {
        private readonly WebStoreContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateDeliveryHandler> _logger;

        public UpdateDeliveryHandler(WebStoreContext context, IMapper mapper, ILogger<UpdateDeliveryHandler> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
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
                _logger.LogError(e, $"UPDATE DELIVERY, HANDLER - {e.Message}");
                throw;
            }
        }
    }
}