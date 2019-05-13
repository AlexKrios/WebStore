using System;
using System.Linq.Expressions;
using DataLibrary.Entities;
using LinqSpecs;

namespace WebStoreAPI.Specifications.OrdersItems
{
    public class OrderItemsMinPriceSpecification : Specification<OrderItems>
    {
        private readonly decimal? _price;

        public OrderItemsMinPriceSpecification(decimal? price)
        {
            _price = price;
        }

        public override Expression<Func<OrderItems, bool>> ToExpression()
        {
            return !_price.HasValue ? (Expression<Func<OrderItems, bool>>) (x => true) : x => x.Price >= _price;
        }
    }
}
