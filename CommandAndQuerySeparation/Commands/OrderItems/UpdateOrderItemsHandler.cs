using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DataLibrary;
using DataLibrary.Entities;
using MediatR;

namespace CommandAndQuerySeparation.Commands.OrderItems
{
    public class UpdateOrderItemsHandler : IRequestHandler<UpdateOrderItemsCommand, OrderItem>
    {
        private readonly WebStoreContext _context;
        private readonly IMapper _mapper;

        public UpdateOrderItemsHandler(WebStoreContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
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
                Console.WriteLine(e);
                throw;
            }
        }
    }
}