using System;
using System.Threading;
using System.Threading.Tasks;
using DataLibrary;
using DataLibrary.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CommandAndQuerySeparation.Queries.Users
{
    public class GetUserByIdHandler : IRequestHandler<GetUserByIdQuery, User>
    {
        private readonly WebStoreContext _context;

        public GetUserByIdHandler(WebStoreContext context)
        {
            _context = context;
        }

        public async Task<User> Handle(GetUserByIdQuery query, CancellationToken cancellationToken)
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
