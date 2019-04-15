using System;
using System.Threading;
using System.Threading.Tasks;
using CQS.Queries.Roles;
using DataLibrary;
using DataLibrary.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CQS.Handlers.Roles
{
    public class GetRoleHandler : IRequestHandler<GetRoleQuery, Role>
    {
        private readonly WebStoreContext _context;

        public GetRoleHandler(WebStoreContext context)
        {
            _context = context;
        }

        public async Task<Role> Handle(GetRoleQuery query, CancellationToken cancellationToken)
        {
            try
            {
                return await _context.Roles.FirstOrDefaultAsync(x => x.Id == query.Id, cancellationToken);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
