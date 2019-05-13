using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CQS.Queries.UsersRoles;
using DataLibrary;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CQS.Handlers.UsersRoles
{
    public class GetUsersRolesHandler : IRequestHandler<GetUsersRolesQuery, IEnumerable<DataLibrary.Entities.UserRoles>>
    {
        private readonly WebStoreContext _context;

        public GetUsersRolesHandler(WebStoreContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<DataLibrary.Entities.UserRoles>> Handle(GetUsersRolesQuery query, CancellationToken cancellationToken)
        {
            try
            {
                return await _context.UsersRoles.Where(query.Specification).ToListAsync(cancellationToken);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}