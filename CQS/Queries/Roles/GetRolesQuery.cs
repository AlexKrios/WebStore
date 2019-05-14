using System.Collections.Generic;
using DataLibrary.Entities;
using LinqSpecs;
using MediatR;

namespace CQS.Queries.Roles
{
    public class GetRolesQuery : IRequest<IEnumerable<Role>>
    {
        public Specification<Role> Specification { get; set; }
    }
}
