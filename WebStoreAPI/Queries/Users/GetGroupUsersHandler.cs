using System.Collections.Generic;
using System.Linq;
using WebStoreAPI.Models;

namespace WebStoreAPI.Queries.Users
{
    //Query for output user of product
    public class GetGroupUsersHandler : GetGroupUsers<IEnumerable<User>>
    {
        private readonly WebStoreContext _context;
        public GetGroupUsersHandler(WebStoreContext context)
        {
            _context = context;
        }

        public override IEnumerable<User> Execute(string role)
        {
            IEnumerable<User> users = _context.Users.Where(x => Equals(x.Role, role));
            return users.ToList();
        }
    }
}
