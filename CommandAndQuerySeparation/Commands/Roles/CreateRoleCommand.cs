using MediatR;

namespace CommandAndQuerySeparation.Commands.Roles
{
    public class CreateRoleCommand : IRequest<CreateRoleCommand>
    {
        public string Name { get; set; }
    }
}
