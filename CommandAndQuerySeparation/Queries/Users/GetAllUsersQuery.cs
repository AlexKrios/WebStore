using System.Collections.Generic;
using DataLibrary.Entities;
using MediatR;

namespace CommandAndQuerySeparation.Queries.Users
{
    public class GetAllUsersQuery : IRequest<IEnumerable<User>>
    {
        
    }
}
