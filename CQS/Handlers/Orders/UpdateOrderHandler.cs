using AutoMapper;
using CQS.Commands.Orders;
using DataLibrary;
using DataLibrary.Entities;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CQS.Handlers.Orders
{
    public class UpdateOrderHandler : IRequestHandler<UpdateOrderCommand, Order>
    {
        private readonly WebStoreContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateOrderHandler> _logger;

        public UpdateOrderHandler(WebStoreContext context, IMapper mapper, ILogger<UpdateOrderHandler> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Order> Handle(UpdateOrderCommand command, CancellationToken cancellationToken)
        {
            try
            {
                if (!_context.Orders.Any(x => x.Id == command.Id)) return null;

                var order = _mapper.Map<Order>(command);

                _context.Orders.Update(order);
                await _context.SaveChangesAsync(cancellationToken);
                return order;
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"UPDATE ORDER, HANDLER - {e.Message}");
                throw;
            }
        }
    }
}