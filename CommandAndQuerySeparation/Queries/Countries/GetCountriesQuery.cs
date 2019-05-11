using System.Collections.Generic;
using DataLibrary.Entities;
using MediatR;

namespace CQS.Queries.Countries
{
    public class GetCountriesQuery : IRequest<IEnumerable<Country>>
    {
        
    }
}