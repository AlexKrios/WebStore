using System.Collections.Generic;
using DataLibrary.Entities;
using MediatR;

namespace WebStoreAPI.Queries.Cities
{
    public class GetAllCitiesQuery : IRequest<IEnumerable<City>>
    {
    }
}
