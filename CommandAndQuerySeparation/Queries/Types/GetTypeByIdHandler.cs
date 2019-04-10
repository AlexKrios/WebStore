using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DataLibrary;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Type = DataLibrary.Entities.Type;

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
            try
            {
                var type = await _context.Types.FirstOrDefaultAsync(x => x.Id == query.Id, cancellationToken);
                var result = _mapper.Map<Type, GetTypeByIdQuery>(type);
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
