using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DataLibrary;
using DataLibrary.Entities;
using MediatR;

namespace WebStoreAPI.Commands.Orders
{
    public class UpdateOrderHandler : IRequestHandler<UpdateOrderCommand, UpdateOrderCommand>
    {
        private readonly WebStoreContext _context;
        private readonly IMapper _mapper;

        public UpdateOrderHandler(WebStoreContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<UpdateOrderCommand> Handle(UpdateOrderCommand command, CancellationToken cancellationToken)
        {
            try
            {
                if (!_context.Orders.Any(x => x.Id == command.Id)) return null;

                _context.Orders.Update(_mapper.Map<Order>(command));
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