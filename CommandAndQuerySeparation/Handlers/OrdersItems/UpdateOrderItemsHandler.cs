using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using CQS.Commands.OrdersItems;
using DataLibrary;
using MediatR;

namespace CQS.Handlers.OrdersItems
{
    public class UpdateOrderItemsHandler : IRequestHandler<UpdateOrderItemsCommand, DataLibrary.Entities.OrderItems>
    {
        private readonly WebStoreContext _context;
        private readonly IMapper _mapper;

        public UpdateOrderItemsHandler(WebStoreContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<DataLibrary.Entities.OrderItems> Handle(UpdateOrderItemsCommand command, CancellationToken cancellationToken)
        {
            try
            {
                if (!_context.OrdersItems.Any(x => x.Id == command.Id)) return null;

                var orderItem = _mapper.Map<DataLibrary.Entities.OrderItems>(command);

                _context.OrdersItems.Update(orderItem);
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