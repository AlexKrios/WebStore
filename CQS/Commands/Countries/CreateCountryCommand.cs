using DataLibrary.Entities;
using MediatR;

namespace CQS.Commands.Countries
{
    public class CreateCountryCommand : IRequest<Country>
    {
        public string Name { get; set; }
    }
}
