using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DataLibrary;
using DataLibrary.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CommandAndQuerySeparation.Queries.Roles
{
    public class GetAllRolesHandler : IRequestHandler<GetAllRolesQuery, IEnumerable<GetAllRolesQuery>>
    {
        private readonly WebStoreContext _context;
        private readonly IMapper _mapper;

        public GetAllRolesHandler(WebStoreContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GetAllRolesQuery>> Handle(GetAllRolesQuery query, CancellationToken cancellationToken)
        {
            var roles = await _context.Roles.ToListAsync(cancellationToken);
            var result = _mapper.Map<IEnumerable<Role>, IEnumerable<GetAllRolesQuery>>(roles);
            return result;
        }
    }
}