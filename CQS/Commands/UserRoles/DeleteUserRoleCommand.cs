using DataLibrary.Entities;
using MediatR;

namespace CQS.Commands.UserRoles
{
    public class DeleteUserRoleCommand : IRequest<UserRole>
    {
        public int Id { get; set; }
    }
}