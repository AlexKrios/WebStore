using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WebStoreAPI.Models;

namespace WebStoreAPI.Queries.Users
{
    //Get single user handler
    public class GetUserByIdHandler : IRequestHandler<GetUserByIdQuery, User>
    {
        private readonly WebStoreContext _context;

        public GetUserByIdHandler(WebStoreContext context)
        {
            _context = context;
        }

        public async Task<User> Handle(GetUserByIdQuery command, CancellationToken cancellationToken)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.Id == command.Id, cancellationToken);
        }
    }
}
