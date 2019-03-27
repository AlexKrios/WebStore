using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebStoreAPI.Models;

namespace WebStoreAPI.Queries.Users
{
    //Get group of users handler
    public class GetGroupUsersHandler : IQueryHandler<GetGroupUsersQueries, IEnumerable<User>>
    {
        private readonly WebStoreContext _context;

        public GetGroupUsersHandler(WebStoreContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<User>> Execute(GetGroupUsersQueries command)
        {
            return await _context.Users.Where(x => Equals(x.Role, command.Role)).ToListAsync();
        }
    }
}
