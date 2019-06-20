using System.Collections.Generic;
using DataLibrary.Entities;
using LinqSpecs;
using MediatR;

namespace CQS.Queries.Users
{
    public class GetUsersQuery : IRequest<IEnumerable<User>>
    {
        public int Skip { get; set; }
        public int Take { get; set; }
        public Specification<User> Specification { get; set; }
    }
}
