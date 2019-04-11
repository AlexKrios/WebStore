using System.Collections.Generic;
using DataLibrary.Entities;
using MediatR;

namespace CommandAndQuerySeparation.Queries.UserRoles
{
    public class GetAllUserRolesQuery : IRequest<IEnumerable<UserRole>>
    {

    }
}
