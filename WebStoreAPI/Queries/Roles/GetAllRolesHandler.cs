using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using DataLibrary;
using DataLibrary.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace WebStoreAPI.Queries.Roles
{
    public class GetAllRolesHandler : IRequestHandler<GetAllRolesQuery, IEnumerable<Role>>
    {
        private readonly WebStoreContext _context;

        public GetAllRolesHandler(WebStoreContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Role>> Handle(GetAllRolesQuery command, CancellationToken cancellationToken)
        {
            return await _context.Roles.ToListAsync(cancellationToken);
        }
    }
}