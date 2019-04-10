using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DataLibrary;
using DataLibrary.Entities;
using MediatR;

namespace CommandAndQuerySeparation.Commands.Orders
{
    public class CreateOrderHandler : IRequestHandler<CreateOrderCommand, CreateOrderCommand>
    {
        private readonly WebStoreContext _context;
        private readonly IMapper _mapper;

        public CreateOrderHandler(WebStoreContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CreateOrderCommand> Handle(CreateOrderCommand command, CancellationToken cancellationToken)
        {
            try
            {
                await _context.Orders.AddAsync(_mapper.Map<Order>(command), cancellationToken);
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
