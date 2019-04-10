using MediatR;

namespace CommandAndQuerySeparation.Commands.Countries
{
    public class CreateCountryCommand : IRequest<CreateCountryCommand>
    {
        public string Name { get; set; }
    }
}
