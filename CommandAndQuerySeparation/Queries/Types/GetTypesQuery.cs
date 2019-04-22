using System.Collections.Generic;
using DataLibrary.Entities;
using MediatR;
using Specification.Requests.Types;
using Specification.Specification.Filters;

namespace CQS.Queries.Types
{
    public class GetTypesQuery : IRequest<IEnumerable<Type>>
    {
        public GetTypesFilter Filter { get; set; }

        public GetTypesQuery(GetTypesRequest filter)
        {
            Filter = new GetTypesFilter(filter);
        }
    }
}
