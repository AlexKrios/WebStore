using System.Collections.Generic;
using MediatR;

namespace CommandAndQuerySeparation.Queries.Types
{
    public class GetAllTypesQuery : IRequest<IEnumerable<GetAllTypesQuery>>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
