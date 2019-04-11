using DataLibrary.Entities;
using MediatR;

namespace CommandAndQuerySeparation.Queries.Countries
{
    public class GetCountryByIdQuery : IRequest<Country>
    {
        public int Id { get; set; }
    }
}
