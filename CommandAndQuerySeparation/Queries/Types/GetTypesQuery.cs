using System.Collections.Generic;
using APIModels.Filters;
using MediatR;
using Type = DataLibrary.Entities.Type;

namespace CQS.Queries.Types
{
    public class GetTypesQuery : IRequest<IEnumerable<Type>>
    {
        public GetTypesFilter Filter { get; set; }
    }
}
