using System.Collections.Generic;
using DataLibrary.Entities;
using MediatR;

namespace CQS.Queries.UserRoles
{
    public class GetUsersRolesQuery : IRequest<IEnumerable<UserRole>>
    {
    }
}
