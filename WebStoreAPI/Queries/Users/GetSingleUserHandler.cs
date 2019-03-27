using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebStoreAPI.Models;

namespace WebStoreAPI.Queries.Users
{
    //Get single user handler
    public class GetSingleUserHandler : IQueryHandler<GetSingleUserQueries, User>
    {
        private readonly WebStoreContext _context;

        public GetSingleUserHandler(WebStoreContext context)
        {
            _context = context;
        }

        public async Task<User> Execute(GetSingleUserQueries command)
        {
             return await _context.Users.FirstOrDefaultAsync(x => x.Id == command.Id);
        }
    }
}
