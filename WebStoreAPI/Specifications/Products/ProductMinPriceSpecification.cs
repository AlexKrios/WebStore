using System;
using System.Linq.Expressions;
using DataLibrary.Entities;
using LinqSpecs;

namespace WebStoreAPI.Specifications.Products
{
    public class ProductMinPriceSpecification : Specification<Product>
    {
        private readonly decimal? _price;

        public ProductMinPriceSpecification(decimal? price)
        {
            _price = price;
        }

        public override Expression<Func<Product, bool>> ToExpression()
        {
            return !_price.HasValue ? (Expression<Func<Product, bool>>) (x => true) : x => x.Price >= _price;
        }
    }
}
