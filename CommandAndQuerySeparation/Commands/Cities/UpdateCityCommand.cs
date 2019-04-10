using MediatR;

namespace CommandAndQuerySeparation.Commands.Cities
{
    public class UpdateCityCommand : IRequest<UpdateCityCommand>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CountryId { get; set; }
    }
}
