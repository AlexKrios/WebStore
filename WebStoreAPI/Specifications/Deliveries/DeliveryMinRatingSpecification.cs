using System;
using System.Linq.Expressions;
using DataLibrary.Entities;
using LinqSpecs;

namespace WebStoreAPI.Specifications.Deliveries
{
    public class DeliveryMinRatingSpecification : Specification<Delivery>
    {
        private readonly float? _rating;

        public DeliveryMinRatingSpecification(float? rating)
        {
            _rating = rating;
        }

        public override Expression<Func<Delivery, bool>> ToExpression()
        {
            if (!_rating.HasValue)
            {
                return x => true;
            }
            return x => x.Rating >= _rating;
        }
    }
}
