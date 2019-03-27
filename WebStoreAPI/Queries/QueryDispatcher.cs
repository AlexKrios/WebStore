using SimpleInjector;

namespace WebStoreAPI.Queries
{
    public class QueryDispatcher : IQueryDispatcher
    {
        private readonly Container _container;

        public QueryDispatcher(Container container)
        {
            _container = container;
        }

        public TResult Execute<TResult, TQuery>(TQuery query)
            where TQuery : IQuery
        {
            var handler = _container.GetInstance<IQueryHandler<TQuery, TResult>>();
            return handler.Execute(query);
        }
    }
}
