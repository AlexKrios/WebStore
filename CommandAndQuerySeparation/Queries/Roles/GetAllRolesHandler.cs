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
    public class GetAllRolesHandler : IRequestHandler<GetAllRolesQuery, IEnumerable<Role>>
    {
        private readonly WebStoreContext _context;

        public GetAllRolesHandler(WebStoreContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Role>> Handle(GetAllRolesQuery query, CancellationToken cancellationToken)
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