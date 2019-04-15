using System.Collections.Generic;
using DataLibrary.Entities;
using MediatR;

namespace CommandAndQuerySeparation.Queries.Users
{
    public class GetUsersQuery : IRequest<IEnumerable<User>>
    {
        
    }
}
