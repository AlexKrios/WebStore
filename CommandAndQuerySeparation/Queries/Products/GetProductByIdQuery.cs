using System;
using MediatR;

namespace CommandAndQuerySeparation.Queries.Products
{
    public class GetProductByIdQuery : IRequest<GetProductByIdQuery>
    {
        public int Id { get; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Availability { get; set; }
        public decimal Price { get; set; }

        public int TypeId { get; set; }
        public int ManufacturerId { get; set; }

        public DateTime CreatedDateTime { get; set; }
        public DateTime ModifiedDateTime { get; set; }
        public int ModifiedBy { get; set; }

        public GetProductByIdQuery(int id)
        {
            Id = id;
        }
    }
}
