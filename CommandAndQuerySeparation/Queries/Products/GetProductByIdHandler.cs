using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DataLibrary;
using DataLibrary.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CommandAndQuerySeparation.Queries.Products
{
    public class GetProductByIdHandler : IRequestHandler<GetProductByIdQuery, GetProductByIdQuery>
    {
        private readonly WebStoreContext _context;
        private readonly IMapper _mapper;

        public GetProductByIdHandler(WebStoreContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<GetProductByIdQuery> Handle(GetProductByIdQuery query, CancellationToken cancellationToken)
        {
            try
            {
                var product = await _context.Products.FirstOrDefaultAsync(x => x.Id == query.Id, cancellationToken);
                var result = _mapper.Map<Product, GetProductByIdQuery>(product);
                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
