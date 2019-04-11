using DataLibrary.Entities;
using MediatR;

namespace CommandAndQuerySeparation.Queries.Cities
{
    public class GetCityByIdQuery : IRequest<City>
    {
        public int Id { get; set; }
    }
}
