using DataLibrary.Entities;
using MediatR;

namespace CommandAndQuerySeparation.Queries.Roles
{
    public class GetRoleByIdQuery : IRequest<GetRoleByIdQuery>
    {
        public int Id { get; }
        public string Name { get; set; }

        public GetRoleByIdQuery(int id)
        {
            Id = id;
        }
    }
}
