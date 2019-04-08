using System.Collections.Generic;
using DataLibrary.Entities;
using MediatR;

namespace WebStoreAPI.Queries.Countries
{
    public class GetAllCountriesQuery : IRequest<IEnumerable<Country>>
    {
    }
}
