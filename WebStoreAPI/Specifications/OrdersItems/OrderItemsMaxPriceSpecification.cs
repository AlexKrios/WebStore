using System;
using System.Linq.Expressions;
using DataLibrary.Entities;
using LinqSpecs;

namespace WebStoreAPI.Specifications.OrdersItems
{
    public class OrderItemsMaxPriceSpecification : Specification<OrderItems>
    {
        private readonly decimal? _price;

        public OrderItemsMaxPriceSpecification(decimal? price)
        {
            _price = price;
        }

        public override Expression<Func<OrderItems, bool>> ToExpression()
        {
            return _price.HasValue 
                ? x => x.Price <= _price
                : (Expression<Func<OrderItems, bool>>)(x => true);
        }
    }
}
