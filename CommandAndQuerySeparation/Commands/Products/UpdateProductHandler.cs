using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DataLibrary;
using DataLibrary.Entities;
using MediatR;

namespace CommandAndQuerySeparation.Commands.Products
{
    public class UpdateProductHandler : IRequestHandler<UpdateProductCommand, UpdateProductCommand>
    {
        private readonly WebStoreContext _context;
        private readonly IMapper _mapper;

        public UpdateProductHandler(WebStoreContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<UpdateProductCommand> Handle(UpdateProductCommand command, CancellationToken cancellationToken)
        {
            try
            {
                if (!_context.Products.Any(x => x.Id == command.Id)) return null;

                _context.Products.Update(_mapper.Map<Product>(command));
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