using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CQS.Queries.Users;
using DataLibrary;
using DataLibrary.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CQS.Handlers.Users
{
    public class GetUsersHandler : IRequestHandler<GetUsersQuery, IEnumerable<User>>
    {
        private readonly WebStoreContext _context;

        public GetUsersHandler(WebStoreContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<User>> Handle(GetUsersQuery query, CancellationToken cancellationToken)
        {
            try
            {
                var result = _context.Users.Where(o => query.Filter.OneOfAll.IsSatisfiedBy(o));
                if (query.Filter.Filter.MinAge != null && query.Filter.Filter.MaxAge != null &&
                    query.Filter.Filter.Email != null && query.Filter.Filter.CityId != null &&
                    query.Filter.Filter.Name != null)
                {
                    result = _context.Users.Where(o => query.Filter.HasAll.IsSatisfiedBy(o));
                }

                if (!result.Any())
                {
                    return await _context.Users.ToListAsync(cancellationToken);
                }

                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
