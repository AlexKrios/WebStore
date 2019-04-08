using MediatR;

namespace WebStoreAPI.Commands.Deliveries
{
    public class CreateDeliveryCommand : IRequest<CreateDeliveryCommand>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public float Rating { get; set; }
    }
}
