using APIModels.Requests.OrderItems;
using DataLibrary.Entities;
using Specification.Specification;

namespace APIModels.Filters
{
    public class GetOrdersItemsFilter
    {
        public GetOrdersItemsRequest Request { get; set; }

        public ISpecification<OrderItem> MinCount =>
            new ExpressionSpecification<OrderItem>(o => o.Count >= Request.MinCount);
        public ISpecification<OrderItem> MaxCount =>
            new ExpressionSpecification<OrderItem>(o => o.Count <= Request.MaxCount);

        public ISpecification<OrderItem> MinPrice =>
            new ExpressionSpecification<OrderItem>(o => o.Price >= Request.MinPrice);
        public ISpecification<OrderItem> MaxPrice =>
            new ExpressionSpecification<OrderItem>(o => o.Price <= Request.MaxPrice);

        public ISpecification<OrderItem> ProductId =>
            new ExpressionSpecification<OrderItem>(o => o.ProductId == Request.ProductId);

        public ISpecification<OrderItem> OrderId =>
            new ExpressionSpecification<OrderItem>(o => o.OrderId == Request.OrderId);
    }
}
