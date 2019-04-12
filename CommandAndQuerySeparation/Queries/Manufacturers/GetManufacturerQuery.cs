using DataLibrary.Entities;
using MediatR;

namespace CommandAndQuerySeparation.Queries.Manufacturers
{
    public class GetManufacturerQuery : IRequest<Manufacturer>
    {
        public int Id { get; set; }
    }
}
