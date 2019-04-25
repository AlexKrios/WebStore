using APIModels.Requests.OrderItems;
using DataLibrary.Entities;
using Specification.Specification;

namespace APIModels.Filters
{
    public class GetOrdersItemsFilter
    {
        public GetOrdersItemsRequest Filter { get; set; }

        public ISpecification<OrderItem> MinCount =>
            new ExpressionSpecification<OrderItem>(o => 
                !Filter.MinCount.HasValue || Filter.MinCount.Value.Equals(0) || o.Count >= Filter.MinCount);
        public ISpecification<OrderItem> MaxCount =>
            new ExpressionSpecification<OrderItem>(o => 
                !Filter.MaxCount.HasValue || Filter.MaxCount.Value.Equals(0) || o.Count <= Filter.MaxCount);

        public ISpecification<OrderItem> MinPrice =>
            new ExpressionSpecification<OrderItem>(o => 
                !Filter.MinPrice.HasValue || Filter.MinPrice.Value.Equals(0) || o.Price >= Filter.MinPrice);
        public ISpecification<OrderItem> MaxPrice =>
            new ExpressionSpecification<OrderItem>(o => 
                !Filter.MaxPrice.HasValue || Filter.MaxPrice.Value.Equals(0) || o.Price <= Filter.MaxPrice);

        public ISpecification<OrderItem> ProductId =>
            new ExpressionSpecification<OrderItem>(o => 
                !Filter.ProductId.HasValue || o.ProductId == Filter.ProductId);

        public ISpecification<OrderItem> OrderId =>
            new ExpressionSpecification<OrderItem>(o => 
                !Filter.OrderId.HasValue || o.OrderId == Filter.OrderId);

        public ISpecification<OrderItem> AllEquals => ProductId.And(MinCount).And(MaxCount).And(MinPrice).And(MaxPrice).And(OrderId);

        public ISpecification<OrderItem> OneOfAll => ProductId.Or(MinCount).And(MaxCount).Or(MinPrice).And(MaxPrice).Or(OrderId);

        public GetOrdersItemsFilter(GetOrdersItemsRequest filter)
        {
            Filter = filter;
        }
    }
}
