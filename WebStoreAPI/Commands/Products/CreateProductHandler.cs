using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using WebStoreAPI.Mapper;
using WebStoreAPI.Models;

namespace WebStoreAPI.Commands.Products
{
    //Post request handler for product
    public class CreateProductHandler : IRequestHandler<CreateProductCommand, ProductDto>
    {
        private readonly WebStoreContext _context;
        private readonly IMapper _mapper;

        public CreateProductHandler(WebStoreContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ProductDto> Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {
            await _context.Products.AddAsync(_mapper.Map<Product>(command.ProductDto), cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return command.ProductDto;
        }
    }
}
