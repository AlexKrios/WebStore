using MediatR;
using WebStoreAPI.Models;

namespace WebStoreAPI.Queries.Users
{
    //Get single user command
    public class GetSingleUserQuery : IRequest<User>
    {
        public int Id { get; }

        public GetSingleUserQuery(int id)
        {
            Id = id;
        }
    }
}
