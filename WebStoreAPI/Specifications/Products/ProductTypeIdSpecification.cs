using System;
using System.Linq.Expressions;
using DataLibrary.Entities;
using LinqSpecs;

namespace WebStoreAPI.Specifications.Products
{
    public class ProductTypeIdSpecification : Specification<Product>
    {
        private readonly int? _typeId;

        public ProductTypeIdSpecification(int? typeId)
        {
            _typeId = typeId;
        }

        public override Expression<Func<Product, bool>> ToExpression()
        {
            return !_typeId.HasValue
                ? (Expression<Func<Product, bool>>)(x => true)
                : x => x.TypeId == _typeId;
        }
    }
}
