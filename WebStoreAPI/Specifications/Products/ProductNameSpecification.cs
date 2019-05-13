using System;
using System.Linq.Expressions;
using DataLibrary.Entities;
using LinqSpecs;

namespace WebStoreAPI.Specifications.Products
{
    public class ProductNameSpecification : Specification<Product>
    {
        private readonly string _name;

        public ProductNameSpecification(string name)
        {
            _name = name;
        }

        public override Expression<Func<Product, bool>> ToExpression()
        {
            return string.IsNullOrEmpty(_name)
                ? (Expression<Func<Product, bool>>) (x => true)
                : x => x.Name.Equals(_name);
        }
    }
}
