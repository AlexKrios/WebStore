using MediatR;

namespace CommandAndQuerySeparation.Commands.Cities
{
    public class DeleteCityCommand : IRequest<DeleteCityCommand>
    {
        public int Id { get; }

        public DeleteCityCommand(int id)
        {
            Id = id;
        }
    }
}
