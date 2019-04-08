using System.Collections.Generic;
using DataLibrary.Entities;
using MediatR;

namespace WebStoreAPI.Queries.Users
{
    public class GetUsersByRoleQuery : IRequest<IEnumerable<User>>
    {
        public string Role { get; }

        public GetUsersByRoleQuery(string role)
        {
            Role = role;
        }
    }
}
