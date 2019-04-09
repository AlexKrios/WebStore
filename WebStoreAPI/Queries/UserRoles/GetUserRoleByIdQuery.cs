using DataLibrary.Entities;
using MediatR;

namespace WebStoreAPI.Queries.UserRoles
{
    public class GetUserRoleByIdQuery : IRequest<UserRole>
    {
        public int Id { get; }

        public GetUserRoleByIdQuery(int id)
        {
            Id = id;
        }
    }
}
