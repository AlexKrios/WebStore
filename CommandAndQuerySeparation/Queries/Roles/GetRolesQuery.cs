using System.Collections.Generic;
using APIModels.Filters;
using APIModels.Requests.Roles;
using DataLibrary.Entities;
using MediatR;

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
