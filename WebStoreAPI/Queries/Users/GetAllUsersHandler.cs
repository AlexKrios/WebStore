using System.Collections.Generic;
using WebStoreAPI.Models;

namespace WebStoreAPI.Queries.Users
{
    public class GetAllUsersHandler : Query<IEnumerable<User>>
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
