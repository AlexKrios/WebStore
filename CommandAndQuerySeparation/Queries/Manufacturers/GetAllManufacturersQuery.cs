using System.Collections.Generic;
using DataLibrary.Entities;
using MediatR;

namespace CommandAndQuerySeparation.Queries.Manufacturers
{
    public class GetAllManufacturersQuery : IRequest<IEnumerable<GetAllManufacturersQuery>>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Contact { get; set; }
        public float Rating { get; set; }
    }
}
