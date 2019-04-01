using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WebStoreAPI.Models;

namespace WebStoreAPI.Queries.Users
{
    //Get all users handler
    public class GetAllUsersHandler : IRequestHandler<GetAllUsersQuery, IEnumerable<User>>
    {
        private readonly WebStoreContext _context;

        public GetAllUsersHandler(WebStoreContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<User>> Handle(GetAllUsersQuery command, CancellationToken cancellationToken)
        {
            return await _context.Users.ToListAsync(cancellationToken);
        }
    }
}
