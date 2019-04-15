using DataLibrary.Entities;
using MediatR;

namespace CommandAndQuerySeparation.Commands.UserRoles
{
    public class DeleteUserRoleCommand : IRequest<UserRole>
    {
        public int Id { get; set; }
    }
}