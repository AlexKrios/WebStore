using MediatR;

namespace WebStoreAPI.Commands.Cities
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
