using MediatR;

namespace CommandAndQuerySeparation.Commands.Manufacturers
{
    public class UpdateManufacturerCommand : IRequest<UpdateManufacturerCommand>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Contact { get; set; }
        public float Rating { get; set; }

    }
}
