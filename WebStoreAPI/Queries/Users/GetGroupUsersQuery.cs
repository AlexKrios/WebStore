using System.Collections.Generic;
using MediatR;
using WebStoreAPI.Models;

namespace WebStoreAPI.Queries.Users
{
    //Get group of users command
    public class GetGroupUsersQuery : IRequest<IEnumerable<User>>
    {
        public string Role { get; }

        public GetGroupUsersQuery(string role)
        {
            Role = role;
        }
    }
}
