using DataLibrary.Entities;
using MediatR;

namespace CommandAndQuerySeparation.Queries.Types
{
    public class GetTypeQuery : IRequest<Type>
    {
        public int Id { get; set; }
    }
}
