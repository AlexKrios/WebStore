using System;
using System.Linq.Expressions;
using DataLibrary.Entities;
using LinqSpecs;

namespace WebStoreAPI.Specifications.Manufacturers
{
    public class ManufacturerMinRatingSpecification : Specification<Manufacturer>
    {
        private readonly float? _rating;

        public ManufacturerMinRatingSpecification(float? rating)
        {
            _rating = rating;
        }

        public override Expression<Func<Manufacturer, bool>> ToExpression()
        {
            return !_rating.HasValue ? (Expression<Func<Manufacturer, bool>>) (x => true) : x => x.Rating >= _rating;
        }
    }
}
