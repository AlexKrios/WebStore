using MediatR;

namespace WebStoreAPI.Commands.Types
{
    public class CreateTypeCommand : IRequest<CreateTypeCommand>
    {
        public string Name { get; set; }
    }
}
