using System;
using System.Linq.Expressions;
using LinqSpecs;

namespace WebStoreAPI.Specifications.OrderItems
{
    public class OrderItemsMinCountSpecification : Specification<DataLibrary.Entities.OrderItems>
    {
        private readonly int? _count;

        public OrderItemsMinCountSpecification(int? count)
        {
            _count = count;
        }

        public override Expression<Func<DataLibrary.Entities.OrderItems, bool>> ToExpression()
        {
            return _count.HasValue 
                ? x => x.Count >= _count
                : (Expression<Func<DataLibrary.Entities.OrderItems, bool>>)(x => true);
        }
    }
}
