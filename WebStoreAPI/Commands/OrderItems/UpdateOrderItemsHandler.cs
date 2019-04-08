using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DataLibrary;
using DataLibrary.Entities;
using MediatR;

namespace WebStoreAPI.Commands.OrderItems
{
    public class UpdateOrderItemsHandler : IRequestHandler<UpdateOrderItemsCommand, UpdateOrderItemsCommand>
    {
        private readonly WebStoreContext _context;
        private readonly IMapper _mapper;

        public UpdateOrderItemsHandler(WebStoreContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<UpdateOrderItemsCommand> Handle(UpdateOrderItemsCommand command, CancellationToken cancellationToken)
        {
            try
            {
                if (!_context.OrderItems.Any(x => x.Id == command.Id)) return null;

                _context.OrderItems.Update(_mapper.Map<OrderItem>(command));
                await _context.SaveChangesAsync(cancellationToken);
                return command;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}