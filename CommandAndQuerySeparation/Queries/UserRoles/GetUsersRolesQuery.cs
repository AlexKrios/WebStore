using System.Collections.Generic;
using DataLibrary.Entities;
using MediatR;
using Specification.Requests.UserRoles;
using Specification.Specification.Filters;

namespace CQS.Queries.UserRoles
{
    public class GetUsersRolesQuery : IRequest<IEnumerable<UserRole>>
    {
        public GetUsersRolesFilter Filter { get; set; }

        public GetUsersRolesQuery(GetUsersRolesRequest filter)
        {
            Filter = new GetUsersRolesFilter(filter);
        }
    }
}
