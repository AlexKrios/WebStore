using DataLibrary.Entities;
using MediatR;

namespace CommandAndQuerySeparation.Commands.Countries
{
    public class UpdateCountryCommand : IRequest<Country>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
