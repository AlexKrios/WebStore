using MediatR;

namespace CommandAndQuerySeparation.Commands.Types
{
    public class DeleteTypeCommand : IRequest<DeleteTypeCommand>
    {
        public int Id { get; set; }
    }
}
