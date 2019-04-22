using DataLibrary.Entities;
using Specification.Requests.OrderItems;

namespace Specification.Specification.Filters
{
    public class GetOrdersItemsFilter
    {
        public static GetOrdersItemsRequest Filter { get; set; }

        public static ISpecification<OrderItem> MinCount =
            new ExpressionSpecification<OrderItem>(o => o.Count >= Filter.MinCount);
        public static ISpecification<OrderItem> MaxCount =
            new ExpressionSpecification<OrderItem>(o => o.Count <= Filter.MaxCount);

        public static ISpecification<OrderItem> MinPrice =
            new ExpressionSpecification<OrderItem>(o => o.Price >= Filter.MinPrice);
        public static ISpecification<OrderItem> MaxPrice =
            new ExpressionSpecification<OrderItem>(o => o.Price <= Filter.MaxPrice);

        public static ISpecification<OrderItem> ProductId =
            new ExpressionSpecification<OrderItem>(o => o.ProductId == Filter.ProductId);

        public static ISpecification<OrderItem> OrderId =
            new ExpressionSpecification<OrderItem>(o => o.OrderId == Filter.OrderId);

        public ISpecification<OrderItem> OneOfAll = ProductId.Or(MinCount).Or(MaxCount).Or(MinPrice).Or(MaxPrice).Or(OrderId);

        public GetOrdersItemsFilter(GetOrdersItemsRequest filter)
        {
            Filter = filter;
        }
    }
}
