using AutoMapper;
using CQS.Commands.Orders;
using DataLibrary;
using DataLibrary.Entities;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CQS.Handlers.Orders
{
    public class CreateOrderHandler : IRequestHandler<CreateOrderCommand, Order>
    {
        private readonly WebStoreContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateOrderHandler> _logger;

        public CreateOrderHandler(WebStoreContext context, IMapper mapper, ILogger<CreateOrderHandler> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Order> Handle(CreateOrderCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var order = _mapper.Map<Order>(command);

                await _context.Orders.AddAsync(order, cancellationToken);
                await _context.SaveChangesAsync(cancellationToken);
                return order;
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"CREATE ORDER, HANDLER - {e.Message}");
                throw;
            }
        }
    }
}
