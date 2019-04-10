using System;
using MediatR;

namespace CommandAndQuerySeparation.Queries.Orders
{
    public class GetOrderByIdQuery : IRequest<GetOrderByIdQuery>
    {
        public int Id { get; }
        public string CustomerNumber { get; set; }
        public string Note { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime OrderTime { get; set; }

        public int UserId { get; set; }
        public int DeliveryId { get; set; }
        public int PaymentId { get; set; }

        public GetOrderByIdQuery(int id)
        {
            Id = id;
        }
    }
}
