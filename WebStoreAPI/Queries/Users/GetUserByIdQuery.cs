using DataLibrary.Entities;
using MediatR;

namespace WebStoreAPI.Queries.Users
{
    //Get single user command
    public class GetUserByIdQuery : IRequest<User>
    {
        public int Id { get; }

        public GetUserByIdQuery(int id)
        {
            Id = id;
        }
    }
}
