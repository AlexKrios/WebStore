using System.Collections.Generic;
using DataLibrary.Entities;
using MediatR;
using Specification.Requests.Cities;
using Specification.Specification.Filters;

namespace CQS.Queries.Cities
{
    public class GetCitiesQuery : IRequest<IEnumerable<City>>
    {
        public GetCitiesFilter Filter { get; set; }

        public GetCitiesQuery(GetCitiesRequest filter)
        {
            Filter = new GetCitiesFilter(filter);
        }
    }
}