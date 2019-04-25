using APIModels.Requests.Products;
using DataLibrary.Entities;
using Specification.Specification;

namespace APIModels.Filters
{
    public class GetProductsFilter
    {
        public GetProductsRequest Filter { get; set; }

        public ISpecification<Product> NameEquals =>
            new ExpressionSpecification<Product>(o =>
                string.IsNullOrEmpty(Filter.Name) || string.IsNullOrWhiteSpace(Filter.Name) || o.Name.Equals(Filter.Name));

        public ISpecification<Product> MinAvailability =>
            new ExpressionSpecification<Product>(o =>
                !Filter.MinAvailability.HasValue || Filter.MinAvailability.Value.Equals(0) || o.Availability >= Filter.MinAvailability);
        public ISpecification<Product> MaxAvailability =>
            new ExpressionSpecification<Product>(o =>
                !Filter.MaxAvailability.HasValue || Filter.MaxAvailability.Value.Equals(0) || o.Availability <= Filter.MaxAvailability);

        public ISpecification<Product> MinPrice =>
            new ExpressionSpecification<Product>(o =>
                !Filter.MinPrice.HasValue || Filter.MinPrice.Value.Equals(0) || o.Price >= Filter.MinPrice);
        public ISpecification<Product> MaxPrice =>
            new ExpressionSpecification<Product>(o =>
                !Filter.MaxPrice.HasValue || Filter.MaxPrice.Value.Equals(0) || o.Price <= Filter.MaxPrice);

        public ISpecification<Product> TypeId =>
            new ExpressionSpecification<Product>(o =>
                !Filter.TypeId.HasValue || o.TypeId == Filter.TypeId);

        public ISpecification<Product> ManufacturerId =>
            new ExpressionSpecification<Product>(o =>
                !Filter.ManufacturerId.HasValue || o.ManufacturerId == Filter.ManufacturerId);

        public ISpecification<Product> AllEquals =>
            NameEquals.And(MinAvailability).And(MaxAvailability).And(MinPrice).And(MaxPrice).And(TypeId).And(ManufacturerId);

        public ISpecification<Product> OneOfAll =>
            NameEquals.Or(MinAvailability).And(MaxAvailability).Or(MinPrice).And(MaxPrice).Or(TypeId).Or(ManufacturerId);

        public GetProductsFilter(GetProductsRequest filter)
        {
            Filter = filter;
        }
    }
}
