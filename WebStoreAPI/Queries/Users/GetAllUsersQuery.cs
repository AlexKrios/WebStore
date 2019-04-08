using System.Collections.Generic;
using DataLibrary.Entities;
using MediatR;

namespace WebStoreAPI.Queries.Users
{
    public class GetAllUsersQuery : IRequest<IEnumerable<User>>
    {
    }
}
