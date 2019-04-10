using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DataLibrary;
using DataLibrary.Entities;
using MediatR;

namespace CommandAndQuerySeparation.Commands.OrderItems
{
    public class CreateOrderItemsHandler : IRequestHandler<CreateOrderItemsCommand, CreateOrderItemsCommand>
    {
        private readonly WebStoreContext _context;
        private readonly IMapper _mapper;

        public CreateOrderItemsHandler(WebStoreContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CreateOrderItemsCommand> Handle(CreateOrderItemsCommand command, CancellationToken cancellationToken)
        {
            try
            {
                await _context.OrderItems.AddAsync(_mapper.Map<OrderItem>(command), cancellationToken);
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
