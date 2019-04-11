using System.Collections.Generic;
using DataLibrary.Entities;
using MediatR;

namespace CommandAndQuerySeparation.Queries.Deliveries
{
    public class GetAllDeliveriesQuery : IRequest<IEnumerable<Delivery>>
    {
        
    }
}
