using System;
using System.Linq.Expressions;
using LinqSpecs;

namespace WebStoreAPI.Specifications.OrderItems
{
    public class OrderItemsOrderIdSpecification : Specification<DataLibrary.Entities.OrderItem>
    {
        private readonly int? _orderId;

        public OrderItemsOrderIdSpecification(int? orderId)
        {
            _orderId = orderId;
        }

        public override Expression<Func<DataLibrary.Entities.OrderItem, bool>> ToExpression()
        {
            return _orderId.HasValue 
                ? x => x.OrderId == _orderId
                : (Expression<Func<DataLibrary.Entities.OrderItem, bool>>)(x => true);
        }
    }
}
