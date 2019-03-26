using SimpleInjector;
using WebStoreAPI.Queries.Products;

namespace WebStoreAPI.Queries
{
    //Query dispatcher
    public class QueryDispatcher : IQueryDispatcher
    {
        private readonly Container _container;
        public QueryDispatcher(Container container)
        {
            _container = container;
        }

        public T Dispatch<TQuery, T>()
            where TQuery : class, IGetAll<T>
        {
            var handler = _container.GetInstance<TQuery>();
            return handler.Execute();
        }

        public T Dispatch<TQuery, T>(int id)
            where TQuery : class, IGetSingle<T>
        {
            var handler = _container.GetInstance<TQuery>();
            return handler.Execute(id);
        }

        public T Dispatch<TQuery, T>(string type)
            where TQuery : class, IGetGroup<T>
        {
            var handler = _container.GetInstance<TQuery>();
            return handler.Execute(type);
        }
    }
}
