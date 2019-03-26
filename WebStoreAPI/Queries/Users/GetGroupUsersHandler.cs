using System.Collections.Generic;
using System.Linq;
using WebStoreAPI.Models;

namespace WebStoreAPI.Queries.Users
{
    //Query for output user of product
    public class GetGroupUsersHandler : Query<IEnumerable<User>>
    {
        public GetGroupUsersHandler(WebStoreContext context) : base(context)
        {
        }

        public override IEnumerable<User> Execute(string role)
        {
            IEnumerable<User> users = Context.Users.Where(x => x.Role == role);
            return users.ToList();
        }
    }
}
