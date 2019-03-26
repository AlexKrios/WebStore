using System.Linq;
using WebStoreAPI.Models;

namespace WebStoreAPI.Queries.Users
{
    public class GetUserHandler : Query<User>
    {
        //Query for output single user
        public GetUserHandler(WebStoreContext context) : base(context)
        {
        }

        public override User Execute(int id)
        {
            var user = Context.Users.FirstOrDefault(x => x.Id == id);
            return user;
        }
    }
}
