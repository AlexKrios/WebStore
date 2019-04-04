using System.Collections.Generic;
using MediatR;
using WebStoreAPI.Models;

namespace WebStoreAPI.Queries.Users
{
    //Get group of users command
    public class GetUsersByRoleQuery : IRequest<IEnumerable<User>>
    {
        public string Role { get; }

        public GetUsersByRoleQuery(string role)
        {
            Role = role;
        }
    }
}
