using System.Collections.Generic;
using DataLibrary.Entities;
using MediatR;

namespace WebStoreAPI.Queries.Types
{
    public class GetAllTypesQuery : IRequest<IEnumerable<Type>>
    {
    }
}
