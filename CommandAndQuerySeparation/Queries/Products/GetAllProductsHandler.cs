using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DataLibrary;
using DataLibrary.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CommandAndQuerySeparation.Queries.Products
{
    public class GetAllProductsHandler : IRequestHandler<GetAllProductsQuery, IEnumerable<GetAllProductsQuery>>
    {
        private readonly WebStoreContext _context;
        private readonly IMapper _mapper;

        public GetAllProductsHandler(WebStoreContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GetAllProductsQuery>> Handle(GetAllProductsQuery query, CancellationToken cancellationToken)
        {
            var products = await _context.Products.ToListAsync(cancellationToken);
            var result = _mapper.Map<IEnumerable<Product>, IEnumerable<GetAllProductsQuery>>(products);
            return result;
        }
    }
}