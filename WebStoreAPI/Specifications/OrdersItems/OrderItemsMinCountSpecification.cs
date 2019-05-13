using System;
using System.Linq.Expressions;
using DataLibrary.Entities;
using LinqSpecs;

namespace WebStoreAPI.Specifications.OrdersItems
{
    public class OrderItemsMinCountSpecification : Specification<OrderItems>
    {
        private readonly int? _count;

        public OrderItemsMinCountSpecification(int? count)
        {
            _count = count;
        }

        public override Expression<Func<OrderItems, bool>> ToExpression()
        {
            return !_count.HasValue ? (Expression<Func<OrderItems, bool>>) (x => true) : x => x.Count >= _count;
        }
    }
}
