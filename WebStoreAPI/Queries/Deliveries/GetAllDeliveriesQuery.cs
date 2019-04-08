using System.Collections.Generic;
using DataLibrary.Entities;
using MediatR;

namespace WebStoreAPI.Queries.Deliveries
{
    public class GetAllDeliveriesQuery : IRequest<IEnumerable<Delivery>>
    {
    }
}
