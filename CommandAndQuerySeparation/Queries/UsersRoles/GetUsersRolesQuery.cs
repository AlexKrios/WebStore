using System.Collections.Generic;
using DataLibrary.Entities;
using LinqSpecs;
using MediatR;

namespace CQS.Queries.UsersRoles
{
    public class GetUsersRolesQuery : IRequest<IEnumerable<UserRoles>>
    {
        public Specification<UserRoles> Specification { get; set; }
    }
}
