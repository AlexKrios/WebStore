using DataLibrary.Entities;
using MediatR;

namespace CommandAndQuerySeparation.Queries.Cities
{
    public class GetCityQuery : IRequest<City>
    {
        public int Id { get; set; }
    }
}
