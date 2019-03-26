using System.Linq;
using WebStoreAPI.Models;

namespace WebStoreAPI.Queries.Users
{
    //Query for output single user
    public class GetSingleUserHandler : Query<User>
    {
        private readonly WebStoreContext _context;
        public GetSingleUserHandler(WebStoreContext context)
        {
            _context = context;
        }

        public override User Execute(int id)
        {
            var user = _context.Users.FirstOrDefault(x => x.Id == id);
            return user;
        }
    }
}
