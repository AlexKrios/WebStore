using System;
using System.Linq.Expressions;
using DataLibrary.Entities;
using LinqSpecs;

namespace WebStoreAPI.Specifications.Users
{
    public class UserCityIdSpecification : Specification<User>
    {
        private readonly int? _cityId;

        public UserCityIdSpecification(int? cityId)
        {
            _cityId = cityId;
        }

        public override Expression<Func<User, bool>> ToExpression()
        {
            return !_cityId.HasValue
                ? (Expression<Func<User, bool>>)(x => true)
                : x => x.CityId == _cityId;
        }
    }
}
