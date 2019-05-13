using System.Collections.Generic;
using LinqSpecs;
using MediatR;

namespace CQS.Queries.OrdersItems
{
    public class GetOrdersItemsQuery : IRequest<IEnumerable<DataLibrary.Entities.OrderItems>>
    {
        public Specification<DataLibrary.Entities.OrderItems> Specification { get; set; }
    }
}
