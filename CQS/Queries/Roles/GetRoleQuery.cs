using DataLibrary.Entities;
using MediatR;

namespace CQS.Queries.Roles
{
    public class GetRoleQuery : IRequest<Role>
    {
        public int Id { get; set; }
    }
}
