using MediatR;

namespace CommandAndQuerySeparation.Commands.Countries
{
    public class UpdateCountryCommand : IRequest<UpdateCountryCommand>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
