using System.Threading.Tasks;

namespace WebStoreAPI.Queries
{
    public interface IQueryDispatcher
    {
        Task<TResult> Execute<TResult, TQuery>(TQuery query)
            where TQuery : IQuery;
    }
}
