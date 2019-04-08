using DataLibrary.Entities;
using MediatR;

namespace WebStoreAPI.Queries.Types
{
    public class GetTypeByIdQuery : IRequest<Type>
    {
        public int Id { get; }

        public GetTypeByIdQuery(int id)
        {
            Id = id;
        }
    }
}
