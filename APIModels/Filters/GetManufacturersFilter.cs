using APIModels.Requests.Manufacturers;
using DataLibrary.Entities;
using Specification.Specification;

namespace APIModels.Filters
{
    public class GetManufacturersFilter
    {
        public GetManufacturersRequest Filter { get; set; }

        public ISpecification<Manufacturer> NameEquals =>
            new ExpressionSpecification<Manufacturer>(o =>
                string.IsNullOrEmpty(Filter.Name) || string.IsNullOrWhiteSpace(Filter.Name) || o.Name.Equals(Filter.Name));

        public ISpecification<Manufacturer> MinRating =>
            new ExpressionSpecification<Manufacturer>(o =>
                !Filter.MinRating.HasValue || Filter.MinRating.Value.Equals(0) || o.Rating >= Filter.MinRating);
        public ISpecification<Manufacturer> MaxRating =>
            new ExpressionSpecification<Manufacturer>(o =>
                !Filter.MaxRating.HasValue || Filter.MaxRating.Value.Equals(0) || o.Rating <= Filter.MaxRating);

        public ISpecification<Manufacturer> AllEquals => NameEquals.And(MinRating).And(MaxRating);

        public ISpecification<Manufacturer> OneOfAll => NameEquals.Or(MinRating).And(MaxRating);

        public GetManufacturersFilter(GetManufacturersRequest filter)
        {
            Filter = filter;
        }
    }
}
