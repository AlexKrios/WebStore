using MediatR;

namespace CQS.Commands.UsersRoles
{
    public class CreateUserRoleCommand : IRequest<DataLibrary.Entities.UserRoles>
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }
    }
}