using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WebStoreAPI.Models;

namespace WebStoreAPI.Queries.Users
{
    //Get single user handler
    public class GetSingleUserHandler : IRequestHandler<GetSingleUserQuery, User>
    {
        private readonly WebStoreContext _context;

        public GetSingleUserHandler(WebStoreContext context)
        {
            _context = context;
        }

        public async Task<User> Handle(GetSingleUserQuery command, CancellationToken cancellationToken)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.Id == command.Id, cancellationToken: cancellationToken);
        }
    }
}
