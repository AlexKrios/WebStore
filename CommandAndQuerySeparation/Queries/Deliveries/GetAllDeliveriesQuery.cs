using System;
using System.Collections.Generic;
using MediatR;

namespace CommandAndQuerySeparation.Queries.Deliveries
{
    public class GetAllDeliveriesQuery : IRequest<IEnumerable<GetAllDeliveriesQuery>>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public float Rating { get; set; }

        public DateTime CreatedDateTime { get; set; }
        public DateTime ModifiedDateTime { get; set; }
        public int ModifiedBy { get; set; }
    }
}
