using DataLibrary.Entities;
using MediatR;

namespace CommandAndQuerySeparation.Commands.Roles
{
    public class DeleteRoleCommand : IRequest<Role>
    {
        public int Id { get; set; }
    }
}
