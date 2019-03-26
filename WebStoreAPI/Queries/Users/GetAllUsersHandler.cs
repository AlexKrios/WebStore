using System.Collections.Generic;
using WebStoreAPI.Models;

namespace WebStoreAPI.Queries.Users
{
    //Query for output all users in table
    public class GetAllUsersHandler : GetAllUsers<IEnumerable<User>>
    {
        private readonly WebStoreContext _context;
        public GetAllUsersHandler(WebStoreContext context)
        {
            _context = context;
        }

        public override IEnumerable<User> Execute()
        {
            return _context.Users;
        }
    }
}
