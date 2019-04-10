using System;
using System.Collections.Generic;
using MediatR;

namespace CommandAndQuerySeparation.Queries.Orders
{
    public class GetAllOrdersQuery : IRequest<IEnumerable<GetAllOrdersQuery>>
    {
        public int Id { get; set; }
        public string CustomerNumber { get; set; }
        public string Note { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime OrderTime { get; set; }

        public int UserId { get; set; }
        public int DeliveryId { get; set; }
        public int PaymentId { get; set; }
    }
}
