using DataLibrary.Entities;
using MediatR;

namespace CommandAndQuerySeparation.Queries.UserRoles
{
    public class GetUserRoleByIdQuery : IRequest<GetUserRoleByIdQuery>
    {
        public int Id { get; }
        public int UserId { get; set; }
        public int RoleId { get; set; }

        public GetUserRoleByIdQuery(int id)
        {
            Id = id;
        }
    }
}
