using System;
using System.Linq.Expressions;
using LinqSpecs;

namespace WebStoreAPI.Specifications.OrderItems
{
    public class OrderItemsOrderIdSpecification : Specification<DataLibrary.Entities.OrderItems>
    {
        private readonly int? _orderId;

        public OrderItemsOrderIdSpecification(int? orderId)
        {
            _orderId = orderId;
        }

        public override Expression<Func<DataLibrary.Entities.OrderItems, bool>> ToExpression()
        {
            return _orderId.HasValue 
                ? x => x.OrderId == _orderId
                : (Expression<Func<DataLibrary.Entities.OrderItems, bool>>)(x => true);
        }
    }
}
