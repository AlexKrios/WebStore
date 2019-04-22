using DataLibrary.Entities;
using Specification.Requests.Orders;

namespace Specification.Specification.Filters
{
    public class GetOrdersFilter
    {
        public static GetOrdersRequest Filter { get; set; }

        public static ISpecification<Order> MinTotalPrice =
            new ExpressionSpecification<Order>(o => o.TotalPrice >= Filter.MinTotalPrice);
        public static ISpecification<Order> MaxTotalPrice =
            new ExpressionSpecification<Order>(o => o.TotalPrice <= Filter.MaxTotalPrice);

        public static ISpecification<Order> UserId =
            new ExpressionSpecification<Order>(o => o.UserId == Filter.UserId);

        public static ISpecification<Order> DeliveryId =
            new ExpressionSpecification<Order>(o => o.DeliveryId == Filter.DeliveryId);

        public static ISpecification<Order> PaymentId =
            new ExpressionSpecification<Order>(o => o.PaymentId == Filter.PaymentId);

        public ISpecification<Order> OneOfAll =
            UserId.Or(MinTotalPrice).Or(MaxTotalPrice).Or(UserId).Or(DeliveryId).Or(PaymentId);

        public GetOrdersFilter(GetOrdersRequest filter)
        {
            Filter = filter;
        }
    }
}
