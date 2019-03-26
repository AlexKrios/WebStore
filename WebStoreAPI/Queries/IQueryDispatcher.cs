using WebStoreAPI.Queries.Products;

namespace WebStoreAPI.Queries
{
    public interface IQueryDispatcher
    {
        T Dispatch<TCommand, T>()
            where TCommand : class, IGetAll<T>;

        T Dispatch<TCommand, T>(int id)
            where TCommand : class, IGetSingle<T>;

        T Dispatch<TCommand, T>(string type)
            where TCommand : class, IGetGroup<T>;
    }
}
