using System;
using System.Linq.Expressions;
using LinqSpecs;

namespace WebStoreAPI.Specifications.OrderItems
{
    public class OrderItemsProductIdSpecification : Specification<DataLibrary.Entities.OrderItems>
    {
        private readonly int? _productId;

        public OrderItemsProductIdSpecification(int? productId)
        {
            _productId = productId;
        }

        public override Expression<Func<DataLibrary.Entities.OrderItems, bool>> ToExpression()
        {
            return _productId.HasValue 
                ? x => x.ProductId == _productId
                : (Expression<Func<DataLibrary.Entities.OrderItems, bool>>)(x => true);
        }
    }
}
