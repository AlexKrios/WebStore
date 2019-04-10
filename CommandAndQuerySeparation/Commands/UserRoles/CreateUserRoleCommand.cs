using MediatR;

namespace CommandAndQuerySeparation.Commands.UserRoles
{
    public class CreateUserRoleCommand : IRequest<CreateUserRoleCommand>
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }
    }
}