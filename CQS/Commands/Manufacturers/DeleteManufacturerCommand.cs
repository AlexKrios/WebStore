using DataLibrary.Entities;
using MediatR;

namespace CQS.Commands.Manufacturers
{
    public class DeleteManufacturerCommand : IRequest<Manufacturer>
    {
        public int Id { get; set; }
    }
}
