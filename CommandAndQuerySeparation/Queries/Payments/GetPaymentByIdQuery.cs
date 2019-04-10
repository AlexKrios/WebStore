using System;
using MediatR;

namespace CommandAndQuerySeparation.Queries.Payments
{
    public class GetPaymentByIdQuery : IRequest<GetPaymentByIdQuery>
    {
        public int Id { get; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Taxes { get; set; }

        public DateTime CreatedDateTime { get; set; }
        public DateTime ModifiedDateTime { get; set; }
        public int ModifiedBy { get; set; }

        public GetPaymentByIdQuery(int id)
        {
            Id = id;
        }
    }
}
