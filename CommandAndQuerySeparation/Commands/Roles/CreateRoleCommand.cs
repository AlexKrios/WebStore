using DataLibrary.Entities;
using MediatR;

namespace CommandAndQuerySeparation.Commands.Roles
{
    public class CreateRoleCommand : IRequest<Role>
    {
        public string Name { get; set; }
    }
}
