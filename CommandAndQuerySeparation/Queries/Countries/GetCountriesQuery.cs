using System.Collections.Generic;
using APIModels.Filters;
using APIModels.Requests.Countries;
using DataLibrary.Entities;
using MediatR;

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