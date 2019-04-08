using DataLibrary.Entities;
using MediatR;

namespace WebStoreAPI.Queries.Cities
{
    public class GetCityByIdQuery : IRequest<City>
    {
        public int Id { get; }

        public GetCityByIdQuery(int id)
        {
            Id = id;
        }
    }
}
