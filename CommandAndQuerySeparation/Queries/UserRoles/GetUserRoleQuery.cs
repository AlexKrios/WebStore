using DataLibrary.Entities;
using MediatR;

namespace CQS.Queries.UserRoles
{
    public class GetUserRoleQuery : IRequest<UserRole>
    {
        public int Id { get; set; }
    }
}
