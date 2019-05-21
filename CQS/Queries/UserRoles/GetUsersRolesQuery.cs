using System.Collections.Generic;
using DataLibrary.Entities;
using LinqSpecs;
using MediatR;

namespace CQS.Queries.UserRoles
{
    public class GetUsersRolesQuery : IRequest<IEnumerable<UserRole>>
    {
        public Specification<UserRole> Specification { get; set; }
    }
}
