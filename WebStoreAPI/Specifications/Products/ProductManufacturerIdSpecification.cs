using System;
using System.Linq.Expressions;
using DataLibrary.Entities;
using LinqSpecs;

namespace WebStoreAPI.Specifications.Products
{
    public class ProductManufacturerIdSpecification : Specification<Product>
    {
        private readonly int? _manufacturerId;

        public ProductManufacturerIdSpecification(int? manufacturerId)
        {
            _manufacturerId = manufacturerId;
        }

        public override Expression<Func<Product, bool>> ToExpression()
        {
            return _manufacturerId.HasValue
                ? x => x.TypeId == _manufacturerId
                : (Expression<Func<Product, bool>>)(x => true);
        }
    }
}
