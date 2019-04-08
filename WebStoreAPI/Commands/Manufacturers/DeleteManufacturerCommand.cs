using MediatR;

namespace WebStoreAPI.Commands.Manufacturers
{
    public class DeleteManufacturerCommand : IRequest<DeleteManufacturerCommand>
    {
        public int Id { get; }

        public DeleteManufacturerCommand(int id)
        {
            Id = id;
        }
    }
}
