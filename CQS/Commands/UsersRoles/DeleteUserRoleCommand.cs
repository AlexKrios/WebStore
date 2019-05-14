using MediatR;

namespace CQS.Commands.UsersRoles
{
    public class DeleteUserRoleCommand : IRequest<DataLibrary.Entities.UserRoles>
    {
        public int Id { get; set; }
    }
}