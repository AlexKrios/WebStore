using System;
using System.Threading;
using System.Threading.Tasks;
using CQS.Queries.Users;
using DataLibrary;
using DataLibrary.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CQS.Handlers.Users
{
    public class GetUserHandler : IRequestHandler<GetUserQuery, User>
    {
        private readonly WebStoreContext _context;

        public GetUserHandler(WebStoreContext context)
        {
            _context = context;
        }

        public async Task<User> Handle(GetUserQuery query, CancellationToken cancellationToken)
        {
            try
            {
                return await _context.Users.FirstOrDefaultAsync(x => x.Id == query.Id, cancellationToken);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
