using DataLibrary.Entities;
using MediatR;

namespace CQS.Commands.Roles
{
    public class DeleteRoleCommand : IRequest<Role>
    {
        public int Id { get; set; }
    }
}
