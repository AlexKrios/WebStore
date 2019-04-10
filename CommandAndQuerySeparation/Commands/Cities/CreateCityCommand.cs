using MediatR;

namespace CommandAndQuerySeparation.Commands.Cities
{
    public class CreateCityCommand : IRequest<CreateCityCommand>
    {
        public string Name { get; set; }
        public int CountryId { get; set; }
    }
}
