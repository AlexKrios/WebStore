using DataLibrary.Entities;
using MediatR;

namespace WebStoreAPI.Queries.Roles
{
    public class GetRoleByIdQuery : IRequest<Role>
    {
        public int Id { get; }

        public GetRoleByIdQuery(int id)
        {
            Id = id;
        }
    }
}
