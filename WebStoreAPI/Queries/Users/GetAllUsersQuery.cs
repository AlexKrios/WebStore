using System.Collections.Generic;
using MediatR;
using WebStoreAPI.Models;

namespace WebStoreAPI.Queries.Users
{
    //Get all users command
    public class GetAllUsersQuery : IRequest<IEnumerable<User>>
    {
    }
}
