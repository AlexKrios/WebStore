using WebStoreAPI.Models;

namespace WebStoreAPI.Queries
{
    //Parent class for query
    public abstract class Query<T> : IQuery<T>
    {
        public readonly WebStoreContext Context;

        protected Query(WebStoreContext context)
        {
            Context = context;
        }

        public virtual T Execute()
        {
            return default(T);
        }
        public virtual T Execute(int id)
        {
            return default(T);
        }
        public virtual T Execute(string type)
        {
            return default(T);
        }
    }
}
