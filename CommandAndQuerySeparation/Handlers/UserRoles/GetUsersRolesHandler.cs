using System;
using System.Collections.Generic;
using System.Linq;
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
                var result = _context.UserRoles.Where(o => query.Filter.OneOfAll.IsSatisfiedBy(o));
                if (!result.Any())
                    return await _context.UserRoles.ToListAsync(cancellationToken);
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