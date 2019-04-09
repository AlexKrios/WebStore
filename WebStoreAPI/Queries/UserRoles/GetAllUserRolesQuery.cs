using System.Collections.Generic;
using DataLibrary.Entities;
using MediatR;

namespace WebStoreAPI.Queries.UserRoles
{
    public class GetAllUserRolesQuery : IRequest<IEnumerable<UserRole>>
    {
    }
}
