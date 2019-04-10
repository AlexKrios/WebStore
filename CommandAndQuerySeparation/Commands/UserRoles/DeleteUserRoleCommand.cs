using MediatR;

namespace CommandAndQuerySeparation.Commands.UserRoles
{
    public class DeleteUserRoleCommand : IRequest<DeleteUserRoleCommand>
    {
        public int Id { get; set; }
    }
}