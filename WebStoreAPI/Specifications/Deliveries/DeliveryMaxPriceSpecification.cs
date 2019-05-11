using System;
using System.Linq.Expressions;
using DataLibrary.Entities;
using LinqSpecs;

namespace WebStoreAPI.Specifications.Deliveries
{
    public class DeliveryMaxPriceSpecification : Specification<Delivery>
    {
        private readonly decimal? _price;

        public DeliveryMaxPriceSpecification(decimal? price)
        {
            _price = price;
        }

        public override Expression<Func<Delivery, bool>> ToExpression()
        {
            if (!_price.HasValue)
            {
                return x => true;
            }
            return x => x.Price <= _price;
        }
    }
}
