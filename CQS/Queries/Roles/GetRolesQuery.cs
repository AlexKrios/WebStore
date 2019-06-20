using System.Collections.Generic;
using DataLibrary.Entities;
using LinqSpecs;
using MediatR;

namespace CQS.Queries.Roles
{
    public class GetRolesQuery : IRequest<IEnumerable<Role>>
    {
        public int Skip { get; set; }
        public int Take { get; set; }
        public Specification<Role> Specification { get; set; }
    }
}
