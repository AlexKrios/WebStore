using System.Collections.Generic;
using DataLibrary.Entities;
using MediatR;
using Specification.Requests.Countries;
using Specification.Specification.Filters;

namespace CQS.Queries.Countries
{
    public class GetCountriesQuery : IRequest<IEnumerable<Country>>
    {
        public GetCountriesFilter Filter { get; set; }

        public GetCountriesQuery(GetCountriesRequest filter)
        {
            Filter = new GetCountriesFilter(filter);
        }
    }
}