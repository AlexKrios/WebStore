namespace WebStoreAPI.Queries
{
    public interface IQueryDispatcher
    {
        T Dispatch<TCommand, T>()
            where TCommand : class, IQuery<T>;

        T Dispatch<TCommand, T>(int id)
            where TCommand : class, IQuery<T>;

        T Dispatch<TCommand, T>(string type)
            where TCommand : class, IQuery<T>;
    }
}
