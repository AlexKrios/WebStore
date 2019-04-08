using DataLibrary.Entities;
using MediatR;

namespace WebStoreAPI.Queries.Countries
{
    public class GetCountryByIdQuery : IRequest<Country>
    {
        public int Id { get; }

        public GetCountryByIdQuery(int id)
        {
            Id = id;
        }
    }
}
