using DataLibrary.Entities;
using MediatR;

namespace CQS.Queries.Manufacturers
{
    public class GetManufacturerQuery : IRequest<Manufacturer>
    {
        public int Id { get; set; }
    }
}
