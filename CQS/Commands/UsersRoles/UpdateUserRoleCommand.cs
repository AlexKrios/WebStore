using MediatR;

namespace CQS.Commands.UsersRoles
{
    public class UpdateUserRoleCommand : IRequest<DataLibrary.Entities.UserRoles>
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int RoleId { get; set; }
    }
}