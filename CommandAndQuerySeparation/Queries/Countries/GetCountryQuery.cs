using DataLibrary.Entities;
using MediatR;

namespace CQS.Queries.Countries
{
    public class GetCountryQuery : IRequest<Country>
    {
        public int Id { get; set; }
    }
}
