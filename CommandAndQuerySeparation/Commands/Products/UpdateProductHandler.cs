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
    public class UpdateProductHandler : IRequestHandler<UpdateProductCommand, Product>
    {
        private readonly WebStoreContext _context;
        private readonly IMapper _mapper;

        public UpdateProductHandler(WebStoreContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Product> Handle(UpdateProductCommand command, CancellationToken cancellationToken)
        {
            try
            {
                if (!_context.Products.Any(x => x.Id == command.Id)) return null;

                var product = _mapper.Map<Product>(command);

                _context.Products.Update(product);
                await _context.SaveChangesAsync(cancellationToken);
                return product;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}