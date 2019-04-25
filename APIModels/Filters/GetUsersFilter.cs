using APIModels.Requests.Users;
using DataLibrary.Entities;
using Specification.Specification;

namespace APIModels.Filters
{
    public class GetUsersFilter
    {
        public GetUsersRequest Filter { get; set; }

        public ISpecification<User> NameEquals =>
            new ExpressionSpecification<User>(o =>
                string.IsNullOrEmpty(Filter.Name) || string.IsNullOrWhiteSpace(Filter.Name) || o.Name.Equals(Filter.Name));

        public ISpecification<User> MinAge =>
            new ExpressionSpecification<User>(o =>
                !Filter.MinAge.HasValue || Filter.MinAge.Value.Equals(0) || o.Age >= Filter.MinAge);
        public ISpecification<User> MaxAge =>
            new ExpressionSpecification<User>(o =>
                !Filter.MaxAge.HasValue || Filter.MaxAge.Value.Equals(0) || o.Age <= Filter.MaxAge);

        public ISpecification<User> EmailEquals =>
            new ExpressionSpecification<User>(o =>
                string.IsNullOrEmpty(Filter.Email) || string.IsNullOrWhiteSpace(Filter.Email) || o.Email.Equals(Filter.Email));

        public ISpecification<User> CityId =>
            new ExpressionSpecification<User>(o =>
                !Filter.CityId.HasValue || o.CityId == Filter.CityId);

        public ISpecification<User> AllEquals => NameEquals.And(MinAge).And(MaxAge).And(EmailEquals).And(CityId);

        public ISpecification<User> OneOfAll => NameEquals.Or(MinAge).And(MaxAge).Or(EmailEquals).Or(CityId);

        public GetUsersFilter(GetUsersRequest filter)
        {
            Filter = filter;
        }
    }
}
