using APIModels.Requests.Products;
using DataLibrary.Entities;
using Specification.Specification;

namespace APIModels.Filters
{
    public class GetProductsFilter
    {
        public GetProductsRequest Request { get; set; }

        public ISpecification<Product> NameEquals =>
            new ExpressionSpecification<Product>(o => o.Name.Equals(Request.Name));

        public ISpecification<Product> MinAvailability =>
            new ExpressionSpecification<Product>(o => o.Availability >= Request.MinAvailability);
        public ISpecification<Product> MaxAvailability =>
            new ExpressionSpecification<Product>(o => o.Availability <= Request.MaxAvailability);

        public ISpecification<Product> MinPrice =>
            new ExpressionSpecification<Product>(o => o.Price >= Request.MinPrice);
        public ISpecification<Product> MaxPrice =>
            new ExpressionSpecification<Product>(o => o.Price <= Request.MaxPrice);

        public ISpecification<Product> TypeId =>
            new ExpressionSpecification<Product>(o => o.TypeId == Request.TypeId);

        public ISpecification<Product> ManufacturerId =>
            new ExpressionSpecification<Product>(o => o.ManufacturerId == Request.ManufacturerId);
    }
}
