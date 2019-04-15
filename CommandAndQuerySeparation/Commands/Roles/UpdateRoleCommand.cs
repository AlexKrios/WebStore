using DataLibrary.Entities;
using MediatR;

namespace CQS.Commands.Roles
{
    public class UpdateRoleCommand : IRequest<Role>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
