using System;
using System.Threading;
using System.Threading.Tasks;
using CQS.Queries.UsersRoles;
using DataLibrary;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CQS.Handlers.UsersRoles
{
    public class GetUserRoleHandler : IRequestHandler<GetUserRoleQuery, DataLibrary.Entities.UserRoles>
    {
        private readonly WebStoreContext _context;

        public GetUserRoleHandler(WebStoreContext context)
        {
            _context = context;
        }

        public async Task<DataLibrary.Entities.UserRoles> Handle(GetUserRoleQuery query, CancellationToken cancellationToken)
        {
            try
            {
                return await _context.UsersRoles.FirstOrDefaultAsync(x => x.Id == query.Id, cancellationToken);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
