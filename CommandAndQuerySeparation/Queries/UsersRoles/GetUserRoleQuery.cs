using MediatR;

namespace CQS.Queries.UsersRoles
{
    public class GetUserRoleQuery : IRequest<DataLibrary.Entities.UserRoles>
    {
        public int Id { get; set; }
    }
}
