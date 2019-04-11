using DataLibrary.Entities;
using MediatR;

namespace CommandAndQuerySeparation.Queries.UserRoles
{
    public class GetUserRoleByIdQuery : IRequest<UserRole>
    {
        public int Id { get; set; }
    }
}
