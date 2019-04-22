using System.Collections.Generic;
using DataLibrary.Entities;
using MediatR;
using Specification.Requests.Users;
using Specification.Specification.Filters;

namespace CQS.Queries.Users
{
    public class GetUsersQuery : IRequest<IEnumerable<User>>
    {
        public GetUsersFilter Filter { get; set; }

        public GetUsersQuery(GetUsersRequest filter)
        {
            Filter = new GetUsersFilter(filter);
        }
    }
}
