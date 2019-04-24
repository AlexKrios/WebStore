using APIModels.Requests.OrderItems;
using DataLibrary.Entities;
using Specification.Specification;

namespace APIModels.Filters
{
    public class GetOrdersItemsFilter
    {
        public GetOrdersItemsRequest Filter { get; set; }

        public ISpecification<OrderItem> MinCount =>
            new ExpressionSpecification<OrderItem>(o => o.Count >= Filter.MinCount);
        public ISpecification<OrderItem> MaxCount =>
            new ExpressionSpecification<OrderItem>(o => o.Count <= Filter.MaxCount);

        public ISpecification<OrderItem> MinPrice =>
            new ExpressionSpecification<OrderItem>(o => o.Price >= Filter.MinPrice);
        public ISpecification<OrderItem> MaxPrice =>
            new ExpressionSpecification<OrderItem>(o => o.Price <= Filter.MaxPrice);

        public ISpecification<OrderItem> ProductId =>
            new ExpressionSpecification<OrderItem>(o => o.ProductId == Filter.ProductId);

        public ISpecification<OrderItem> OrderId =>
            new ExpressionSpecification<OrderItem>(o => o.OrderId == Filter.OrderId);

        public ISpecification<OrderItem> HasAll => ProductId.And(MinCount).And(MaxCount).And(MinPrice).And(MaxPrice).And(OrderId);

        public ISpecification<OrderItem> OneOfAll => ProductId.Or(MinCount).Or(MaxCount).Or(MinPrice).Or(MaxPrice).Or(OrderId);

        public GetOrdersItemsFilter(GetOrdersItemsRequest filter)
        {
            Filter = filter;
        }
    }
}
