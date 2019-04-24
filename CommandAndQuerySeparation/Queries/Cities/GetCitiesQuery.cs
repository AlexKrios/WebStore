using System.Collections.Generic;
using APIModels.Filters;
using APIModels.Requests.Cities;
using DataLibrary.Entities;
using MediatR;

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