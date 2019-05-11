using System.Collections.Generic;
using DataLibrary.Entities;
using MediatR;

namespace CQS.Queries.Roles
{
    public class GetRolesQuery : IRequest<IEnumerable<Role>>
    {
    }
}
