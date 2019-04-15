using DataLibrary.Entities;
using MediatR;

namespace CommandAndQuerySeparation.Commands.Countries
{
    public class CreateCountryCommand : IRequest<Country>
    {
        public string Name { get; set; }
    }
}
