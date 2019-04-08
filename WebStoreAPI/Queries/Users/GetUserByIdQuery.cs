using DataLibrary.Entities;
using MediatR;

namespace WebStoreAPI.Queries.Users
{
    public class GetUserByIdQuery : IRequest<User>
    {
        public int Id { get; }

        public GetUserByIdQuery(int id)
        {
            Id = id;
        }
    }
}
