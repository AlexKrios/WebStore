using System;
using System.Linq.Expressions;
using DataLibrary.Entities;
using LinqSpecs;

namespace WebStoreAPI.Specifications.Orders
{
    public class OrderDeliveryIdSpecification : Specification<Order>
    {
        private readonly int? _deliveryId;

        public OrderDeliveryIdSpecification(int? deliveryId)
        {
            _deliveryId = deliveryId;
        }

        public override Expression<Func<Order, bool>> ToExpression()
        {
            return _deliveryId.HasValue
                ? x => x.DeliveryId >= _deliveryId
                : (Expression<Func<Order, bool>>)(x => true);
        }
    }
}
