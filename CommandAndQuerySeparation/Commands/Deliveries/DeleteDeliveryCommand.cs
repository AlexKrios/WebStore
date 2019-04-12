using DataLibrary.Entities;
using MediatR;

namespace CommandAndQuerySeparation.Commands.Deliveries
{
    public class DeleteDeliveryCommand : IRequest<Delivery>
    {
        public int Id { get; set; }
    }
}
