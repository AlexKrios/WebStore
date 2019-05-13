using System;
using System.Linq.Expressions;
using DataLibrary.Entities;
using LinqSpecs;

namespace WebStoreAPI.Specifications.Orders
{
    public class OrderUserIdSpecification : Specification<Order>
    {
        private readonly int? _orderId;

        public OrderUserIdSpecification(int? orderId)
        {
            _orderId = orderId;
        }

        public override Expression<Func<Order, bool>> ToExpression()
        {
            return !_orderId.HasValue ? (Expression<Func<Order, bool>>) (x => true) : x => x.UserId >= _orderId;
        }
    }
}
