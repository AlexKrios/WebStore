using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebStoreAPI.Models;

namespace WebStoreAPI.Queries.Users
{
    //Get all users handler
    public class GetAllUsersHandler : IQueryHandler<GetAllUsersQueries, IEnumerable<User>>
    {
        private readonly WebStoreContext _context;

        public GetAllUsersHandler(WebStoreContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<User>> Execute(GetAllUsersQueries command)
        {
            return await _context.Users.ToListAsync();
        }
    }
}
