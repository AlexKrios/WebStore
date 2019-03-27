using System.Linq;
using WebStoreAPI.Models;

namespace WebStoreAPI.Queries.Users
{
    //Get single user handler
    public class GetSingleUserHandler : IQueryHandler<GetSingleUserCommand, User>
    {
        private readonly WebStoreContext _context;

        public GetSingleUserHandler(WebStoreContext context)
        {
            _context = context;
        }

        public User Execute(GetSingleUserCommand command)
        {
            var user = _context.Users.FirstOrDefault(x => x.Id == command.Id);
            return user;
        }
    }
}
