using DataLibrary.Entities;
using MediatR;

namespace CommandAndQuerySeparation.Queries.UserRoles
{
    public class GetUserRoleQuery : IRequest<UserRole>
    {
        public int Id { get; set; }
    }
}
