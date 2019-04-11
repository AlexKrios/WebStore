using DataLibrary.Entities;
using MediatR;

namespace CommandAndQuerySeparation.Queries.Manufacturers
{
    public class GetManufacturerByIdQuery : IRequest<Manufacturer>
    {
        public int Id { get; set; }
    }
}
