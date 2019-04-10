using MediatR;

namespace CommandAndQuerySeparation.Commands.Countries
{
    public class DeleteCountryCommand : IRequest<DeleteCountryCommand>
    {
        public int Id { get; set; }
    }
}
