using System;
using System.Linq.Expressions;
using DataLibrary.Entities;
using LinqSpecs;

namespace WebStoreAPI.Specifications.Countries
{
    public class CountryNameSpecification : Specification<Country>
    {
        private readonly string _name;

        public CountryNameSpecification(string name)
        {
            _name = name;
        }

        public override Expression<Func<Country, bool>> ToExpression()
        {
            return string.IsNullOrEmpty(_name)
                ? (Expression<Func<Country, bool>>) (x => true)
                : x => x.Name.Equals(_name);
        }
    }
}
