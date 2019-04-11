using System;
using System.Threading;
using System.Threading.Tasks;
using DataLibrary;
using DataLibrary.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CommandAndQuerySeparation.Queries.Roles
{
    public class GetRoleByIdHandler : IRequestHandler<GetRoleByIdQuery, Role>
    {
        private readonly WebStoreContext _context;

        public GetRoleByIdHandler(WebStoreContext context)
        {
            _context = context;
        }

        public async Task<Role> Handle(GetRoleByIdQuery query, CancellationToken cancellationToken)
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
