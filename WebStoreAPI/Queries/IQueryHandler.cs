using System.Threading.Tasks;

namespace WebStoreAPI.Queries
{
    public interface IQueryHandler<in TQuery, TResult>
        where TQuery : IQuery
    {
        Task<TResult> Execute(TQuery query);
    }
}