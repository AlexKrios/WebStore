using System;
using System.Linq.Expressions;
using DataLibrary.Entities;
using LinqSpecs;

namespace WebStoreAPI.Specifications.Manufacturers
{
    public class ManufacturerMaxRatingSpecification : Specification<Manufacturer>
    {
        private readonly float? _rating;

        public ManufacturerMaxRatingSpecification(float? rating)
        {
            _rating = rating;
        }

        public override Expression<Func<Manufacturer, bool>> ToExpression()
        {
            return _rating.HasValue 
                ? x => x.Rating <= _rating 
                : (Expression<Func<Manufacturer, bool>>)(x => true);
        }
    }
}
