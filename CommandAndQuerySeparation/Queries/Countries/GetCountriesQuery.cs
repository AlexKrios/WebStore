using System.Collections.Generic;
using APIModels.Filters;
using DataLibrary.Entities;
using MediatR;

namespace CQS.Queries.Countries
{
    public class GetCountriesQuery : IRequest<IEnumerable<Country>>
    {
        public GetCountriesFilter Filter { get; set; }
    }
}