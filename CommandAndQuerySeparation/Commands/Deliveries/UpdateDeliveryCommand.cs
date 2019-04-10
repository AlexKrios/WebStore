using MediatR;

namespace CommandAndQuerySeparation.Commands.Deliveries
{
    public class UpdateDeliveryCommand : IRequest<UpdateDeliveryCommand>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public float Rating { get; set; }
    }
}
