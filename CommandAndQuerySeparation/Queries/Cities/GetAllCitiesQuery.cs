using System.Collections.Generic;
using MediatR;

namespace CommandAndQuerySeparation.Queries.Cities
{
    public class GetAllCitiesQuery : IRequest<IEnumerable<GetAllCitiesQuery>>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CountryId { get; set; }
    }
}