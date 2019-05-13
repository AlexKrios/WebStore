using System;
using System.Linq.Expressions;
using DataLibrary.Entities;
using LinqSpecs;

namespace WebStoreAPI.Specifications.Deliveries
{
    public class DeliveryMaxRatingSpecification : Specification<Delivery>
    {
        private readonly float? _rating;

        public DeliveryMaxRatingSpecification(float? rating)
        {
            _rating = rating;
        }

        public override Expression<Func<Delivery, bool>> ToExpression()
        {
            return !_rating.HasValue ? (Expression<Func<Delivery, bool>>) (x => true) : x => x.Rating <= _rating;
        }
    }
}
