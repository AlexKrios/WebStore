using DataLibrary.Entities;
using MediatR;

namespace CQS.Commands.Deliveries
{
    public class DeleteDeliveryCommand : IRequest<Delivery>
    {
        public int Id { get; set; }
    }
}
