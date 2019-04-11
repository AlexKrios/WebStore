using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using DataLibrary;
using DataLibrary.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CommandAndQuerySeparation.Queries.UserRoles
{
    public class GetAllUserRolesHandler : IRequestHandler<GetAllUserRolesQuery, IEnumerable<UserRole>>
    {
        private readonly WebStoreContext _context;

        public GetAllUserRolesHandler(WebStoreContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<UserRole>> Handle(GetAllUserRolesQuery query, CancellationToken cancellationToken)
        {
            try
            {
                return await _context.UserRoles.ToListAsync(cancellationToken);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}