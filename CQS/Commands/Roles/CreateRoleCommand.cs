using DataLibrary.Entities;
using MediatR;

namespace CQS.Commands.Roles
{
    public class CreateRoleCommand : IRequest<Role>
    {
        public string Name { get; set; }
    }
}
