using System.Collections.Generic;
using DataLibrary.Entities;
using MediatR;

namespace CommandAndQuerySeparation.Queries.Cities
{
    public class GetAllCitiesQuery : IRequest<IEnumerable<City>>
    {
        public int Id { get; set; }
    }
}