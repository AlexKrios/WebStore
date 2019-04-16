using System.Collections.Generic;
using DataLibrary.Entities;
using MediatR;

namespace CQS.Queries.Users
{
    public class GetUsersQuery : IRequest<IEnumerable<User>>
    {
        
    }
}
