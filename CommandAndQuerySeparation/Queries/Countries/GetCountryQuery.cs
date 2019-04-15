using DataLibrary.Entities;
using MediatR;

namespace CommandAndQuerySeparation.Queries.Countries
{
    public class GetCountryQuery : IRequest<Country>
    {
        public int Id { get; set; }
    }
}
