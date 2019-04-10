using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DataLibrary;
using DataLibrary.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CommandAndQuerySeparation.Queries.Types
{
    public class GetTypeByIdHandler : IRequestHandler<GetTypeByIdQuery, GetTypeByIdQuery>
    {
        private readonly WebStoreContext _context;
        private readonly IMapper _mapper;

        public GetTypeByIdHandler(WebStoreContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<GetTypeByIdQuery> Handle(GetTypeByIdQuery query, CancellationToken cancellationToken)
        {
            var type = await _context.Types.FirstOrDefaultAsync(x => x.Id == query.Id, cancellationToken);
            var result = _mapper.Map<Type, GetTypeByIdQuery>(type);
            return result;
        }
    }
}
