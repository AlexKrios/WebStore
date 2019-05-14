using DataLibrary.Entities;
using MediatR;

namespace CQS.Commands.Manufacturers
{
    public class UpdateManufacturerCommand : IRequest<Manufacturer>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Contact { get; set; }
        public float Rating { get; set; }

    }
}
