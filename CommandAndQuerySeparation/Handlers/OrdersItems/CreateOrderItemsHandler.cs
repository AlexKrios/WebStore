using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using CQS.Commands.OrdersItems;
using DataLibrary;
using MediatR;

namespace CQS.Handlers.OrdersItems
{
    public class CreateOrderItemsHandler : IRequestHandler<CreateOrderItemsCommand, DataLibrary.Entities.OrderItems>
    {
        private readonly WebStoreContext _context;
        private readonly IMapper _mapper;

        public CreateOrderItemsHandler(WebStoreContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<DataLibrary.Entities.OrderItems> Handle(CreateOrderItemsCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var orderItems = _mapper.Map<DataLibrary.Entities.OrderItems>(command);

                await _context.OrdersItems.AddAsync(orderItems, cancellationToken);
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
