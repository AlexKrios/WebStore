using AutoMapper;
using CQS.Commands.Deliveries;
using DataLibrary;
using DataLibrary.Entities;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CQS.Handlers.Deliveries
{
    public class CreateDeliveryHandler : IRequestHandler<CreateDeliveryCommand, Delivery>
    {
        private readonly WebStoreContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateDeliveryHandler> _logger;

        public CreateDeliveryHandler(WebStoreContext context, IMapper mapper, ILogger<CreateDeliveryHandler> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
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
                _logger.LogError(e, $"CREATE DELIVERY, HANDLER - {e.Message}");
                throw;
            }
        }
    }
}
