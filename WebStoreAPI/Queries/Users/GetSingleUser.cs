namespace WebStoreAPI.Queries.Users
{
    public class GetSingleUser<T> : IGetSingle<T>
    {
        public virtual T Execute(int id)
        {
            return default(T);
        }
    }
}
