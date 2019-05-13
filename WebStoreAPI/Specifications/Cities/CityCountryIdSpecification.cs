using System;
using System.Linq.Expressions;
using DataLibrary.Entities;
using LinqSpecs;

namespace WebStoreAPI.Specifications.Cities
{
    public class CityCountryIdSpecification : Specification<City>
    {
        private readonly int? _countryId;

        public CityCountryIdSpecification(int? countryId)
        {
            _countryId = countryId;
        }

        public override Expression<Func<City, bool>> ToExpression()
        {
            return !_countryId.HasValue ? (Expression<Func<City, bool>>) (x => true) : x => x.CountryId == _countryId;
        }
    }
}
