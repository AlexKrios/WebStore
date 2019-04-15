using DataLibrary.Entities;
using MediatR;

namespace CQS.Commands.Deliveries
{
    public class CreateDeliveryCommand : IRequest<Delivery>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public float Rating { get; set; }
    }
}
