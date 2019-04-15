using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using DataLibrary;
using DataLibrary.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CommandAndQuerySeparation.Queries.Roles
{
    public class GetRolesHandler : IRequestHandler<GetRolesQuery, IEnumerable<Role>>
    {
        private readonly WebStoreContext _context;

        public GetRolesHandler(WebStoreContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Role>> Handle(GetRolesQuery query, CancellationToken cancellationToken)
        {
            try
            {
                return await _context.Roles.ToListAsync(cancellationToken);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}