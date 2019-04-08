using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DataLibrary;
using DataLibrary.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace WebStoreAPI.Queries.Users
{
    public class GetUsersByRoleHandler : IRequestHandler<GetUsersByRoleQuery, IEnumerable<User>>
    {
        private readonly WebStoreContext _context;

        public GetUsersByRoleHandler(WebStoreContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<User>> Handle(GetUsersByRoleQuery command, CancellationToken cancellationToken)
        {
            return await _context.Users.Where(x => Equals(x.Name, command.Role)).ToListAsync(cancellationToken);
        }
    }
}
