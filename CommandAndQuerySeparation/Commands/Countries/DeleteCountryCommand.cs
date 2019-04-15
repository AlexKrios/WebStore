using DataLibrary.Entities;
using MediatR;

namespace CommandAndQuerySeparation.Commands.Countries
{
    public class DeleteCountryCommand : IRequest<Country>
    {
        public int Id { get; set; }
    }
}
