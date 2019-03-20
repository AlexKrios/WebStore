using System.Collections.Generic;

namespace WebStoreAPI.Queries
{
    public interface IQueriesService<out T>
    {
        IEnumerable<T> GetAll();
        T GetSingle(int id);
        IEnumerable<T> GetGroup(string str);
    }
}
