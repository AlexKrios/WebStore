using System.Collections.Generic;
using System.Linq;
using WebStoreAPI.Models;

namespace WebStoreAPI.Queries.Users
{
    //Get group of users handler
    public class GetGroupUsersHandler : IQueryHandler<GetGroupUsersCommand, IEnumerable<User>>
    {
        private readonly WebStoreContext _context;

        public GetGroupUsersHandler(WebStoreContext context)
        {
            _context = context;
        }

        public IEnumerable<User> Execute(GetGroupUsersCommand command)
        {
            IEnumerable<User> users = _context.Users.Where(x => Equals(x.Role, command.Role));
            return users.ToList();
        }
    }
}
