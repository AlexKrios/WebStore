namespace WebStoreAPI.Queries
{
    public interface IQueryDispatcher
    {
        TResult Execute<TResult, TQuery>(TQuery query)
            where TQuery : IQuery;
    }
}
