using MediatR;

namespace CommandAndQuerySeparation.Commands.Manufacturers
{
    public class DeleteManufacturerCommand : IRequest<DeleteManufacturerCommand>
    {
        public int Id { get; set; }
    }
}
