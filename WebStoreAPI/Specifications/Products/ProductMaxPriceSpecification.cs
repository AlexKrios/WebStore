using System;
using System.Linq.Expressions;
using DataLibrary.Entities;
using LinqSpecs;

namespace WebStoreAPI.Specifications.Products
{
    public class ProductMaxPriceSpecification : Specification<Product>
    {
        private readonly decimal? _price;

        public ProductMaxPriceSpecification(decimal? price)
        {
            _price = price;
        }

        public override Expression<Func<Product, bool>> ToExpression()
        {
            return _price.HasValue 
                ? x => x.Price <= _price
                : (Expression<Func<Product, bool>>)(x => true);
        }
    }
}
