using DataLibrary.Entities;
using MediatR;

namespace CommandAndQuerySeparation.Commands.Cities
{
    public class DeleteCityCommand : IRequest<City>
    {
        public int Id { get; set; }
    }
}
