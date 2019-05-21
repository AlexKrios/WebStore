using System.Collections.Generic;
using DataLibrary.Entities;
using LinqSpecs;
using MediatR;

namespace CQS.Queries.Users
{
    public class GetUsersQuery : IRequest<IEnumerable<User>>
    {
        public Specification<User> Specification { get; set; }
    }
}
