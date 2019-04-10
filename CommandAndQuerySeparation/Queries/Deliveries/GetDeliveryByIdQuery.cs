using System;
using DataLibrary.Entities;
using MediatR;

namespace CommandAndQuerySeparation.Queries.Deliveries
{
    public class GetDeliveryByIdQuery : IRequest<GetDeliveryByIdQuery>
    {
        public int Id { get; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public float Rating { get; set; }

        public DateTime CreatedDateTime { get; set; }
        public DateTime ModifiedDateTime { get; set; }
        public int ModifiedBy { get; set; }

        public GetDeliveryByIdQuery(int id)
        {
            Id = id;
        }
    }
}
