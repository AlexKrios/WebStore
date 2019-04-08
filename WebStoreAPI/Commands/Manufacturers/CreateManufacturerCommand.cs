using MediatR;

namespace WebStoreAPI.Commands.Manufacturers
{
    public class CreateManufacturerCommand : IRequest<CreateManufacturerCommand>
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Contact { get; set; }
        public float Rating { get; set; }
        
    }
}
