using System;
using System.Collections.Generic;
using DataLibrary.Entities;
using MediatR;

namespace CommandAndQuerySeparation.Queries.Payments
{
    public class GetAllPaymentsQuery : IRequest<IEnumerable<GetAllPaymentsQuery>>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Taxes { get; set; }

        public DateTime CreatedDateTime { get; set; }
        public DateTime ModifiedDateTime { get; set; }
        public int ModifiedBy { get; set; }
    }
}
