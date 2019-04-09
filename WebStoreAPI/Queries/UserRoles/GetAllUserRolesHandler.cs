using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using DataLibrary;
using DataLibrary.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace WebStoreAPI.Queries.UserRoles
{
    public class GetAllUserRolesHandler : IRequestHandler<GetAllUserRolesQuery, IEnumerable<UserRole>>
    {
        private readonly WebStoreContext _context;

        public GetAllUserRolesHandler(WebStoreContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<UserRole>> Handle(GetAllUserRolesQuery command, CancellationToken cancellationToken)
        {
            return await _context.UserRoles.ToListAsync(cancellationToken);
        }
    }
}