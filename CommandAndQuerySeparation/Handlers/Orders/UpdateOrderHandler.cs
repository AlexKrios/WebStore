using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using CQS.Commands.Orders;
using DataLibrary;
using DataLibrary.Entities;
using MediatR;

namespace CQS.Handlers.Orders
{
    public class UpdateOrderHandler : IRequestHandler<UpdateOrderCommand, Order>
    {
        private readonly WebStoreContext _context;
        private readonly IMapper _mapper;

        public UpdateOrderHandler(WebStoreContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
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
                Console.WriteLine(e);
                throw;
            }
        }
    }
}