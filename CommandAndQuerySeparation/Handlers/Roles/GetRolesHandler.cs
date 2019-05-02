using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CQS.Queries.Roles;
using DataLibrary;
using DataLibrary.Entities;
using MediatR;

namespace CQS.Handlers.Roles
{
    public class GetRolesHandler : IRequestHandler<GetRolesQuery, IEnumerable<Role>>
    {
        private readonly WebStoreContext _context;

        public GetRolesHandler(WebStoreContext context)
        {
            _context = context;
        }

        public Task<IEnumerable<Role>> Handle(GetRolesQuery query, CancellationToken cancellationToken)
        {
            try
            {
                var list = _context.Roles as IEnumerable<Role>;

                if (!string.IsNullOrEmpty(query.Filter.Request.Name))
                {
                    list = _context.Roles.Where(o => query.Filter.NameEquals.IsSatisfiedBy(o));
                }

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