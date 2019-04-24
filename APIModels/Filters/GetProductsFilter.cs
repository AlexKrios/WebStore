using APIModels.Requests.Products;
using DataLibrary.Entities;
using Specification.Specification;

namespace APIModels.Filters
{
    public class GetProductsFilter
    {
        public GetProductsRequest Filter { get; set; }

        public ISpecification<Product> HasName =>
            new ExpressionSpecification<Product>(o => o.Name.Equals(Filter.Name));

        public ISpecification<Product> MinAvailability =>
            new ExpressionSpecification<Product>(o => o.Availability >= Filter.MinAvailability);
        public ISpecification<Product> MaxAvailability =>
            new ExpressionSpecification<Product>(o => o.Availability <= Filter.MaxAvailability);

        public ISpecification<Product> MinPrice =>
            new ExpressionSpecification<Product>(o => o.Price >= Filter.MinPrice);
        public ISpecification<Product> MaxPrice =>
            new ExpressionSpecification<Product>(o => o.Price <= Filter.MaxPrice);

        public ISpecification<Product> TypeId =>
            new ExpressionSpecification<Product>(o => o.TypeId == Filter.TypeId);

        public ISpecification<Product> ManufacturerId =>
            new ExpressionSpecification<Product>(o => o.ManufacturerId == Filter.ManufacturerId);

        public ISpecification<Product> HasAll =>
            HasName.And(MinAvailability).And(MaxAvailability).And(MinPrice).And(MaxPrice).And(TypeId).And(ManufacturerId);

        public ISpecification<Product> OneOfAll =>
            HasName.Or(MinAvailability).Or(MaxAvailability).Or(MinPrice).Or(MaxPrice).Or(TypeId).Or(ManufacturerId);

        public GetProductsFilter(GetProductsRequest filter)
        {
            Filter = filter;
        }
    }
}
