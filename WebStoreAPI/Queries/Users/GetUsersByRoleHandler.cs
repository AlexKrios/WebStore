using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WebStoreAPI.Models;

namespace WebStoreAPI.Queries.Users
{
    //Get group of users handler
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
