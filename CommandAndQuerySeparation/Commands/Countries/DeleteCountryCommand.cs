using DataLibrary.Entities;
using MediatR;

namespace CQS.Commands.Countries
{
    public class DeleteCountryCommand : IRequest<Country>
    {
        public int Id { get; set; }
    }
}
