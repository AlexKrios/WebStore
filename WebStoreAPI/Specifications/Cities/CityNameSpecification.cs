using System;
using System.Linq.Expressions;
using DataLibrary.Entities;
using LinqSpecs;

namespace WebStoreAPI.Specifications.Cities
{
    public class CityNameSpecification : Specification<City>
    {
        private readonly string _name;

        public CityNameSpecification(string name)
        {
            _name = name;
        }

        public override Expression<Func<City, bool>> ToExpression()
        {
            return string.IsNullOrEmpty(_name)
                ? (Expression<Func<City, bool>>) (x => true)
                : x => x.Name.Equals(_name);
        }
    }
}
