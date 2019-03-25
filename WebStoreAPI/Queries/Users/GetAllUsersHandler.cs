using System.Collections.Generic;
using WebStoreAPI.Models;

namespace WebStoreAPI.Queries.Users
{
    //Query for output all users in table
    public class GetAllUsersHandler : Query<IEnumerable<User>>
    {
        public GetAllUsersHandler(WebStoreContext context) : base(context)
        {
        }

        public override IEnumerable<User> Execute()
        {
            return Context.Users;
        }
    }
}
