using System;
using System.Threading;
using System.Threading.Tasks;
using DataLibrary;
using DataLibrary.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CommandAndQuerySeparation.Queries.UserRoles
{
    public class GetUserRoleByIdHandler : IRequestHandler<GetUserRoleByIdQuery, UserRole>
    {
        private readonly WebStoreContext _context;

        public GetUserRoleByIdHandler(WebStoreContext context)
        {
            _context = context;
        }

        public async Task<UserRole> Handle(GetUserRoleByIdQuery query, CancellationToken cancellationToken)
        {
            try
            {
                return await _context.UserRoles.FirstOrDefaultAsync(x => x.Id == query.Id, cancellationToken);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
