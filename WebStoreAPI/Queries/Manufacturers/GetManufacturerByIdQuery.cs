using DataLibrary.Entities;
using MediatR;

namespace WebStoreAPI.Queries.Manufacturers
{
    public class GetManufacturerByIdQuery : IRequest<Manufacturer>
    {
        public int Id { get; }

        public GetManufacturerByIdQuery(int id)
        {
            Id = id;
        }
    }
}
