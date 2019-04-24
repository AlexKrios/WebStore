using System.Collections.Generic;
using APIModels.Filters;
using APIModels.Requests.UserRoles;
using DataLibrary.Entities;
using MediatR;

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
