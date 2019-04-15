using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using CQS.Commands.Products;
using DataLibrary;
using DataLibrary.Entities;
using MediatR;

namespace CQS.Handlers.Products
{
    public class CreateProductHandler : IRequestHandler<CreateProductCommand, Product>
    {
        private readonly WebStoreContext _context;
        private readonly IMapper _mapper;

        public CreateProductHandler(WebStoreContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Product> Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var product = _mapper.Map<Product>(command);

                await _context.Products.AddAsync(product, cancellationToken);
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
