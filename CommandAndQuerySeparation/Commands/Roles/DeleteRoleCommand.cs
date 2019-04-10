using MediatR;

namespace CommandAndQuerySeparation.Commands.Roles
{
    public class DeleteRoleCommand : IRequest<DeleteRoleCommand>
    {
        public int Id { get; set; }
    }
}
