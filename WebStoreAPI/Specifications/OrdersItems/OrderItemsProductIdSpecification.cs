using System;
using System.Linq.Expressions;
using DataLibrary.Entities;
using LinqSpecs;

namespace WebStoreAPI.Specifications.OrdersItems
{
    public class OrderItemsProductIdSpecification : Specification<OrderItems>
    {
        private readonly int? _productId;

        public OrderItemsProductIdSpecification(int? productId)
        {
            _productId = productId;
        }

        public override Expression<Func<OrderItems, bool>> ToExpression()
        {
            return !_productId.HasValue ? (Expression<Func<OrderItems, bool>>) (x => true) : x => x.ProductId == _productId;
        }
    }
}
