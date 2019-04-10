using System.Collections.Generic;
using MediatR;

namespace CommandAndQuerySeparation.Queries.Countries
{
    public class GetAllCountriesQuery : IRequest<IEnumerable<GetAllCountriesQuery>>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}