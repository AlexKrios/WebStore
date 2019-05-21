using DataLibrary.Entities;
using MediatR;

namespace CQS.Commands.Cities
{
    public class DeleteCityCommand : IRequest<City>
    {
        public int Id { get; set; }
    }
}