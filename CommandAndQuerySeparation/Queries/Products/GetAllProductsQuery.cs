using System;
using System.Collections.Generic;
using MediatR;

namespace CommandAndQuerySeparation.Queries.Products
{
    public class GetAllProductsQuery : IRequest<IEnumerable<GetAllProductsQuery>>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Availability { get; set; }
        public decimal Price { get; set; }

        public int TypeId { get; set; }
        public int ManufacturerId { get; set; }

        public DateTime CreatedDateTime { get; set; }
        public DateTime ModifiedDateTime { get; set; }
        public int ModifiedBy { get; set; }
    }
}
