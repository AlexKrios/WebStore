using System.Collections.Generic;
using DataLibrary.Entities;
using MediatR;

namespace WebStoreAPI.Queries.Users
{
    //Get all users command
    public class GetAllUsersQuery : IRequest<IEnumerable<User>>
    {
    }
}
