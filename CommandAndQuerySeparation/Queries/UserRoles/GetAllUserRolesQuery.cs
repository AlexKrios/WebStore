using System.Collections.Generic;
using MediatR;

namespace CommandAndQuerySeparation.Queries.UserRoles
{
    public class GetAllUserRolesQuery : IRequest<IEnumerable<GetAllUserRolesQuery>>
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int RoleId { get; set; }
    }
}
