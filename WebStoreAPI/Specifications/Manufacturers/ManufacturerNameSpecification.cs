using System;
using System.Linq.Expressions;
using DataLibrary.Entities;
using LinqSpecs;

namespace WebStoreAPI.Specifications.Manufacturers
{
    public class ManufacturerNameSpecification : Specification<Manufacturer>
    {
        private readonly string _name;

        public ManufacturerNameSpecification(string name)
        {
            _name = name;
        }

        public override Expression<Func<Manufacturer, bool>> ToExpression()
        {
            return string.IsNullOrEmpty(_name)
                ? (Expression<Func<Manufacturer, bool>>) (x => true)
                : x => x.Name.Equals(_name);
        }
    }
}
