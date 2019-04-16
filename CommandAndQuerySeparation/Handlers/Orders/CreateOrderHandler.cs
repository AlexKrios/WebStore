using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using CQS.Commands.Orders;
using DataLibrary;
using DataLibrary.Entities;
using MediatR;

namespace CQS.Handlers.Orders
{
    public class CreateOrderHandler : IRequestHandler<CreateOrderCommand, Order>
    {
        private readonly WebStoreContext _context;
        private readonly IMapper _mapper;

        public CreateOrderHandler(WebStoreContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
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
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
