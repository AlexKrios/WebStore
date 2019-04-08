using MediatR;

namespace WebStoreAPI.Commands.Countries
{
    public class CreateCountryCommand : IRequest<CreateCountryCommand>
    {
        public string Name { get; set; }
    }
}
