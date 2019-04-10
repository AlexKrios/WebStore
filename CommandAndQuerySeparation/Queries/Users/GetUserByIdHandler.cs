using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DataLibrary;
using DataLibrary.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CommandAndQuerySeparation.Queries.Users
{
    public class GetUserByIdHandler : IRequestHandler<GetUserByIdQuery, GetUserByIdQuery>
    {
        private readonly WebStoreContext _context;
        private readonly IMapper _mapper;

        public GetUserByIdHandler(WebStoreContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<GetUserByIdQuery> Handle(GetUserByIdQuery query, CancellationToken cancellationToken)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == query.Id, cancellationToken);
            var result = _mapper.Map<User, GetUserByIdQuery>(user);
            return result;
        }
    }
}
