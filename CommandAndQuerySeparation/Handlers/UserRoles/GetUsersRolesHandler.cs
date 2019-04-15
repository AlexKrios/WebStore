using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CQS.Queries.UserRoles;
using DataLibrary;
using DataLibrary.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CQS.Handlers.UserRoles
{
    public class GetUsersRolesHandler : IRequestHandler<GetUsersRolesQuery, IEnumerable<UserRole>>
    {
        private readonly WebStoreContext _context;

        public GetUsersRolesHandler(WebStoreContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<UserRole>> Handle(GetUsersRolesQuery query, CancellationToken cancellationToken)
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