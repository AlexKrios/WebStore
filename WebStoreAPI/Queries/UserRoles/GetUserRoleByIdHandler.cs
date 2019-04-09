using System.Threading;
using System.Threading.Tasks;
using DataLibrary;
using DataLibrary.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace WebStoreAPI.Queries.UserRoles
{
    public class GetUserRoleByIdHandler : IRequestHandler<GetUserRoleByIdQuery, UserRole>
    {
        private readonly WebStoreContext _context;

        public GetUserRoleByIdHandler(WebStoreContext context)
        {
            _context = context;
        }

        public async Task<UserRole> Handle(GetUserRoleByIdQuery command, CancellationToken cancellationToken)
        {
            return await _context.UserRoles.FirstOrDefaultAsync(x => x.Id == command.Id, cancellationToken);
        }
    }
}
