using MediatR;

namespace CommandAndQuerySeparation.Commands.Types
{
    public class CreateTypeCommand : IRequest<CreateTypeCommand>
    {
        public string Name { get; set; }
    }
}
