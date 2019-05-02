using APIModels.Requests.Deliveries;
using DataLibrary.Entities;
using Specification.Specification;

namespace APIModels.Filters
{
    public class GetDeliveriesFilter
    {
        public GetDeliveriesRequest Request { get; set; }

        public ISpecification<Delivery> NameEquals =>
            new ExpressionSpecification<Delivery>(o => o.Name.Equals(Request.Name));

        public ISpecification<Delivery> MinPrice =>
            new ExpressionSpecification<Delivery>(o => o.Price >= Request.MinPrice);
        public ISpecification<Delivery> MaxPrice =>
            new ExpressionSpecification<Delivery>(o => o.Price <= Request.MaxPrice);

        public ISpecification<Delivery> MinRating =>
            new ExpressionSpecification<Delivery>(o => o.Rating >= Request.MinRating);
        public ISpecification<Delivery> MaxRating =>
            new ExpressionSpecification<Delivery>(o => o.Rating <= Request.MaxRating);
    }
}
