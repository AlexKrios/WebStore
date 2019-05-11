using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CQS.Queries.UserRoles;
using DataLibrary;
using DataLibrary.Entities;
using MediatR;

namespace CQS.Handlers.UserRoles
{
    public class GetUsersRolesHandler : IRequestHandler<GetUsersRolesQuery, IEnumerable<UserRole>>
    {
        private readonly WebStoreContext _context;

        public GetUsersRolesHandler(WebStoreContext context)
        {
            _context = context;
        }

        public Task<IEnumerable<UserRole>> Handle(GetUsersRolesQuery query, CancellationToken cancellationToken)
        {
            try
            {
                var list = _context.UserRoles as IEnumerable<UserRole>;

                //if (query.Filter.Request.UserId.HasValue)
                //{
                //    list = _context.UserRoles.Where(o => query.Filter.UserId.IsSatisfiedBy(o));
                //}

                //if (query.Filter.Request.RoleId.HasValue)
                //{
                //    list = _context.UserRoles.Where(o => query.Filter.RoleId.IsSatisfiedBy(o));
                //}

                return Task.FromResult(list);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}