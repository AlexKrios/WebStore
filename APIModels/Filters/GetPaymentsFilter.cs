using APIModels.Requests.Payments;
using DataLibrary.Entities;
using Specification.Specification;

namespace APIModels.Filters
{
    public class GetPaymentsFilter
    {
        public GetPaymentsRequest Filter { get; set; }

        public ISpecification<Payment> HasName =>
            new ExpressionSpecification<Payment>(o => o.Name.Equals(Filter.Name));

        public ISpecification<Payment> MinTaxes =>
            new ExpressionSpecification<Payment>(o => o.Taxes >= Filter.MinTaxes);
        public ISpecification<Payment> MaxTaxes =>
            new ExpressionSpecification<Payment>(o => o.Taxes <= Filter.MaxTaxes);

        public ISpecification<Payment> HasAll => HasName.And(MinTaxes).And(MaxTaxes);

        public ISpecification<Payment> OneOfAll => HasName.Or(MinTaxes).Or(MaxTaxes);

        public GetPaymentsFilter(GetPaymentsRequest filter)
        {
            Filter = filter;
        }
    }
}
