namespace WebStoreAPI.Queries.Users
{
    public class GetAllUsers<T> : IGetAll<T>
    {
        public virtual T Execute()
        {
            return default(T);
        }
    }
}
