using DataLibrary.Entities;
using MediatR;

namespace CQS.Commands.Cities
{
    public class UpdateCityCommand : IRequest<City>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CountryId { get; set; }
    }
}
