using APIModels.Requests.Manufacturers;
using DataLibrary.Entities;
using Specification.Specification;

namespace APIModels.Filters
{
    public class GetManufacturersFilter
    {
        public GetManufacturersRequest Filter { get; set; }

        public ISpecification<Manufacturer> HasName =>
            new ExpressionSpecification<Manufacturer>(o => o.Name.Equals(Filter.Name));

        public ISpecification<Manufacturer> MinRating =>
            new ExpressionSpecification<Manufacturer>(o => o.Rating >= Filter.MinRating);
        public ISpecification<Manufacturer> MaxRating =>
            new ExpressionSpecification<Manufacturer>(o => o.Rating <= Filter.MaxRating);

        public ISpecification<Manufacturer> HasAll => HasName.And(MinRating).And(MaxRating);

        public ISpecification<Manufacturer> OneOfAll => HasName.Or(MinRating).Or(MaxRating);

        public GetManufacturersFilter(GetManufacturersRequest filter)
        {
            Filter = filter;
        }
    }
}
