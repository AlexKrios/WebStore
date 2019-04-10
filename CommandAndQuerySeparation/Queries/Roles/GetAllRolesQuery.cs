using System.Collections.Generic;
using DataLibrary.Entities;
using MediatR;

namespace CommandAndQuerySeparation.Queries.Roles
{
    public class GetAllRolesQuery : IRequest<IEnumerable<GetAllRolesQuery>>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
