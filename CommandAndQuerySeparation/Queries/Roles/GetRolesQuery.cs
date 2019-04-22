using System.Collections.Generic;
using DataLibrary.Entities;
using MediatR;
using Specification.Requests.Roles;
using Specification.Specification.Filters;

namespace CQS.Queries.Roles
{
    public class GetRolesQuery : IRequest<IEnumerable<Role>>
    {
        public GetRolesFilter Filter { get; set; }

        public GetRolesQuery(GetRolesRequest filter)
        {
            Filter = new GetRolesFilter(filter);
        }
    }
}
