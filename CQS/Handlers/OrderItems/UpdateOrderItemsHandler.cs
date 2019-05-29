using AutoMapper;
using CQS.Commands.OrderItems;
using DataLibrary;
using DataLibrary.Entities;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CQS.Handlers.OrderItems
{
    public class UpdateOrderItemsHandler : IRequestHandler<UpdateOrderItemsCommand, OrderItem>
    {
        private readonly WebStoreContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateOrderItemsHandler> _logger;

        public UpdateOrderItemsHandler(WebStoreContext context, IMapper mapper, ILogger<UpdateOrderItemsHandler> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<OrderItem> Handle(UpdateOrderItemsCommand command, CancellationToken cancellationToken)
        {
            try
            {
                if (!_context.OrderItems.Any(x => x.Id == command.Id)) return null;

                var orderItem = _mapper.Map<OrderItem>(command);

                _context.OrderItems.Update(orderItem);
                await _context.SaveChangesAsync(cancellationToken);
                return orderItem;
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"UPDATE ORDERITEMS, HANDLER - {e.Message}");
                throw;
            }
        }
    }
}