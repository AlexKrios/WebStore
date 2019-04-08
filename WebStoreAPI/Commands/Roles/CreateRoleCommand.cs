using MediatR;

namespace WebStoreAPI.Commands.Roles
{
    public class CreateRoleCommand : IRequest<CreateRoleCommand>
    {
        public string Name { get; set; }
    }
}
