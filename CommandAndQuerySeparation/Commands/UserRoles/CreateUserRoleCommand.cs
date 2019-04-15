using DataLibrary.Entities;
using MediatR;

namespace CQS.Commands.UserRoles
{
    public class CreateUserRoleCommand : IRequest<UserRole>
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }
    }
}