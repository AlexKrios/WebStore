using MediatR;

namespace CommandAndQuerySeparation.Commands.Types
{
    public class DeleteTypeCommand : IRequest<DeleteTypeCommand>
    {
        public int Id { get; }

        public DeleteTypeCommand(int id)
        {
            Id = id;
        }
    }
}
