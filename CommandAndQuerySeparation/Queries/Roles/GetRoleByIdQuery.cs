using DataLibrary.Entities;
using MediatR;

namespace CommandAndQuerySeparation.Queries.Roles
{
    public class GetRoleByIdQuery : IRequest<Role>
    {
        public int Id { get; set; }
    }
}
