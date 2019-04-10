using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DataLibrary;
using DataLibrary.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CommandAndQuerySeparation.Queries.Types
{
    public class GetAllTypesHandler : IRequestHandler<GetAllTypesQuery, IEnumerable<GetAllTypesQuery>>
    {
        private readonly WebStoreContext _context;
        private readonly IMapper _mapper;

        public GetAllTypesHandler(WebStoreContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GetAllTypesQuery>> Handle(GetAllTypesQuery query, CancellationToken cancellationToken)
        {
            var types = await _context.Types.ToListAsync(cancellationToken);
            var result = _mapper.Map<IEnumerable<Type>, IEnumerable<GetAllTypesQuery>>(types);
            return result;
        }
    }
}