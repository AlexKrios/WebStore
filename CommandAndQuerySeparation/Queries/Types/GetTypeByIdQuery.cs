using DataLibrary.Entities;
using MediatR;

namespace CommandAndQuerySeparation.Queries.Types
{
    public class GetTypeByIdQuery : IRequest<GetTypeByIdQuery>
    {
        public int Id { get; }
        public string Name { get; set; }

        public GetTypeByIdQuery(int id)
        {
            Id = id;
        }
    }
}
