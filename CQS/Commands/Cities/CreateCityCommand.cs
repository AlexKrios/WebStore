using DataLibrary.Entities;
using MediatR;

namespace CQS.Commands.Cities
{
    public class CreateCityCommand : IRequest<City>
    {
        public string Name { get; set; }
        public int CountryId { get; set; }
    }
}
