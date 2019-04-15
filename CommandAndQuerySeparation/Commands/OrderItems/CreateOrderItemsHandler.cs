using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DataLibrary;
using DataLibrary.Entities;
using MediatR;

namespace CommandAndQuerySeparation.Commands.OrderItems
{
    public class CreateOrderItemsHandler : IRequestHandler<CreateOrderItemsCommand, OrderItem>
    {
        private readonly WebStoreContext _context;
        private readonly IMapper _mapper;

        public CreateOrderItemsHandler(WebStoreContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
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
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
