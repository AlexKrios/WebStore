using MediatR;

namespace CommandAndQuerySeparation.Commands.Cities
{
    public class DeleteCityCommand : IRequest<DeleteCityCommand>
    {
        public int Id { get; set; }
    }
}
