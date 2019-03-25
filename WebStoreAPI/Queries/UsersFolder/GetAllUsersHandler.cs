using System.Collections.Generic;
using WebStoreAPI.Models;

namespace WebStoreAPI.Queries.UsersFolder
{
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
