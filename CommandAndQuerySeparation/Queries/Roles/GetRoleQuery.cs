using DataLibrary.Entities;
using MediatR;

namespace CommandAndQuerySeparation.Queries.Roles
{
    public class GetRoleQuery : IRequest<Role>
    {
        public int Id { get; set; }
    }
}
