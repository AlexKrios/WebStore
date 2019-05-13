using System;
using System.Linq.Expressions;
using DataLibrary.Entities;
using LinqSpecs;

namespace WebStoreAPI.Specifications.Deliveries
{
    public class DeliveryMinPriceSpecification : Specification<Delivery>
    {
        private readonly decimal? _price;

        public DeliveryMinPriceSpecification(decimal? price)
        {
            _price = price;
        }

        public override Expression<Func<Delivery, bool>> ToExpression()
        {
            return !_price.HasValue ? (Expression<Func<Delivery, bool>>) (x => true) : x => x.Price >= _price;
        }
    }
}
