using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using WebStoreAPI.Models;

namespace WebStoreAPI.Commands.Products
{
    //Put request handler for product
    public class UpdateProductHandler : IRequestHandler<UpdateProductCommand>
    {
        private readonly WebStoreContext _context;
        private readonly IMapper _mapper;

        public UpdateProductHandler(WebStoreContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateProductCommand command, CancellationToken cancellationToken)
        {
            _context.Products.Update(_mapper.Map<Product>(command));
            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
