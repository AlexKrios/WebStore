using DataLibrary.Entities;
using MediatR;

namespace CommandAndQuerySeparation.Commands.UserRoles
{
    public class UpdateUserRoleCommand : IRequest<UserRole>
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int RoleId { get; set; }
    }
}