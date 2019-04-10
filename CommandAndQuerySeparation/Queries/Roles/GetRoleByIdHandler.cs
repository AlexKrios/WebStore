using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DataLibrary;
using DataLibrary.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CommandAndQuerySeparation.Queries.Roles
{
    public class GetRoleByIdHandler : IRequestHandler<GetRoleByIdQuery, GetRoleByIdQuery>
    {
        private readonly WebStoreContext _context;
        private readonly IMapper _mapper;

        public GetRoleByIdHandler(WebStoreContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<GetRoleByIdQuery> Handle(GetRoleByIdQuery query, CancellationToken cancellationToken)
        {
            var role = await _context.Roles.FirstOrDefaultAsync(x => x.Id == query.Id, cancellationToken);
            var result = _mapper.Map<Role, GetRoleByIdQuery>(role);
            return result;
        }
    }
}
