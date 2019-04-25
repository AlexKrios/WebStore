using APIModels.Requests.Payments;
using DataLibrary.Entities;
using Specification.Specification;

namespace APIModels.Filters
{
    public class GetPaymentsFilter
    {
        public GetPaymentsRequest Filter { get; set; }

        public ISpecification<Payment> NameEquals =>
            new ExpressionSpecification<Payment>(o => o.Name.Equals(Filter.Name));

        public ISpecification<Payment> MinTaxes =>
            new ExpressionSpecification<Payment>(o => 
                !Filter.MinTaxes.HasValue || Filter.MinTaxes.Value.Equals(0) || o.Taxes >= Filter.MinTaxes);
        public ISpecification<Payment> MaxTaxes =>
            new ExpressionSpecification<Payment>(o => 
                !Filter.MaxTaxes.HasValue || Filter.MaxTaxes.Value.Equals(0) || o.Taxes <= Filter.MaxTaxes);

        public ISpecification<Payment> AllEquals => NameEquals.And(MinTaxes).And(MaxTaxes);

        public ISpecification<Payment> OneOfAll => NameEquals.Or(MinTaxes).And(MaxTaxes);

        public GetPaymentsFilter(GetPaymentsRequest filter)
        {
            Filter = filter;
        }
    }
}
