using DataLibrary.Entities;
using MediatR;

namespace CQS.Queries.Cities
{
    public class GetCityQuery : IRequest<City>
    {
        public int Id { get; set; }
    }
}
