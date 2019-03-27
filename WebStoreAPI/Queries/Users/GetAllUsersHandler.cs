using System.Collections.Generic;
using WebStoreAPI.Models;

namespace WebStoreAPI.Queries.Users
{
    //Get all users handler
    public class GetAllUsersHandler : IQueryHandler<GetAllUsersCommand, IEnumerable<User>>
    {
        private readonly WebStoreContext _context;

        public GetAllUsersHandler(WebStoreContext context)
        {
            _context = context;
        }

        public IEnumerable<User> Execute(GetAllUsersCommand command)
        {
            return _context.Users;
        }
    }
}
