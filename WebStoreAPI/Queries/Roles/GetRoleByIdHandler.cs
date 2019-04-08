using System.Threading;
using System.Threading.Tasks;
using DataLibrary;
using DataLibrary.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace WebStoreAPI.Queries.Roles
{
    public class GetRoleByIdHandler : IRequestHandler<GetRoleByIdQuery, Role>
    {
        private readonly WebStoreContext _context;

        public GetRoleByIdHandler(WebStoreContext context)
        {
            _context = context;
        }

        public async Task<Role> Handle(GetRoleByIdQuery command, CancellationToken cancellationToken)
        {
            return await _context.Roles.FirstOrDefaultAsync(x => x.Id == command.Id, cancellationToken);
        }
    }
}
