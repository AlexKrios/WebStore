using AutoMapper;
using CQS.Commands.OrderItems;
using DataLibrary;
using DataLibrary.Entities;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CQS.Handlers.OrderItems
{
    public class CreateOrderItemsHandler : IRequestHandler<CreateOrderItemsCommand, OrderItem>
    {
        private readonly WebStoreContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateOrderItemsHandler> _logger;

        public CreateOrderItemsHandler(WebStoreContext context, IMapper mapper, ILogger<CreateOrderItemsHandler> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<OrderItem> Handle(CreateOrderItemsCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var orderItems = _mapper.Map<OrderItem>(command);

                await _context.OrderItems.AddAsync(orderItems, cancellationToken);
                await _context.SaveChangesAsync(cancellationToken);
                return orderItems;
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"CREATE ORDERITEMS, HANDLER - {e.Message}");
                throw;
            }
        }
    }
}
