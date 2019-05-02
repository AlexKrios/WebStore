using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CQS.Queries.Users;
using DataLibrary;
using DataLibrary.Entities;
using MediatR;

namespace CQS.Handlers.Users
{
    public class GetUsersHandler : IRequestHandler<GetUsersQuery, IEnumerable<User>>
    {
        private readonly WebStoreContext _context;

        public GetUsersHandler(WebStoreContext context)
        {
            _context = context;
        }

        public Task<IEnumerable<User>> Handle(GetUsersQuery query, CancellationToken cancellationToken)
        {
            try
            {
                var list = _context.Users as IEnumerable<User>;

                if (query.Filter.Request.MinAge.HasValue)
                {
                    list = _context.Users.Where(o => query.Filter.MinAge.IsSatisfiedBy(o));
                }

                if (query.Filter.Request.MaxAge.HasValue)
                {
                    list = _context.Users.Where(o => query.Filter.MaxAge.IsSatisfiedBy(o));
                }

                if (query.Filter.Request.CityId.HasValue)
                {
                    list = _context.Users.Where(o => query.Filter.CityId.IsSatisfiedBy(o));
                }

                if (!string.IsNullOrEmpty(query.Filter.Request.Name))
                {
                    list = _context.Users.Where(o => query.Filter.NameEquals.IsSatisfiedBy(o));
                }

                if (!string.IsNullOrEmpty(query.Filter.Request.Email))
                {
                    list = _context.Users.Where(o => query.Filter.EmailEquals.IsSatisfiedBy(o));
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