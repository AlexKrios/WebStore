using System.Collections.Generic;
using DataLibrary.Entities;
using MediatR;

namespace WebStoreAPI.Queries.Roles
{
    public class GetAllRolesQuery : IRequest<IEnumerable<Role>>
    {
    }
}
