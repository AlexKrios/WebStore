using DataLibrary.Entities;
using Specification.Specification;

namespace APIModels.Filters
{
    public class GetOrdersFilter
    {
        public GetOrdersRequest Request { get; set; }

        public ISpecification<Order> MinTotalPrice =>
            new ExpressionSpecification<Order>(o => o.TotalPrice >= Request.MinTotalPrice);
        public ISpecification<Order> MaxTotalPrice =>
            new ExpressionSpecification<Order>(o => o.TotalPrice <= Request.MaxTotalPrice);

        public ISpecification<Order> UserId =>
            new ExpressionSpecification<Order>(o => o.UserId == Request.UserId);

        public ISpecification<Order> DeliveryId =>
            new ExpressionSpecification<Order>(o => o.DeliveryId == Request.DeliveryId);

        public ISpecification<Order> PaymentId =>
            new ExpressionSpecification<Order>(o => o.PaymentId == Request.PaymentId);
    }
}
