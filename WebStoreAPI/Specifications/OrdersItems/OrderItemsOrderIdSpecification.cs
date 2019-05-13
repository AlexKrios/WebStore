using System;
using System.Linq.Expressions;
using DataLibrary.Entities;
using LinqSpecs;

namespace WebStoreAPI.Specifications.OrdersItems
{
    public class OrderItemsOrderIdSpecification : Specification<OrderItems>
    {
        private readonly int? _orderId;

        public OrderItemsOrderIdSpecification(int? orderId)
        {
            _orderId = orderId;
        }

        public override Expression<Func<OrderItems, bool>> ToExpression()
        {
            return _orderId.HasValue 
                ? x => x.OrderId == _orderId
                : (Expression<Func<OrderItems, bool>>)(x => true);
        }
    }
}
