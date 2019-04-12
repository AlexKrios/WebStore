using DataLibrary.Entities;
using MediatR;

namespace CommandAndQuerySeparation.Commands.Manufacturers
{
    public class DeleteManufacturerCommand : IRequest<Manufacturer>
    {
        public int Id { get; set; }
    }
}
