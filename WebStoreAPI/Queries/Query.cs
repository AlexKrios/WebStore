namespace WebStoreAPI.Queries
{
    public abstract class Query<T> : IQuery<T>
    {
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
