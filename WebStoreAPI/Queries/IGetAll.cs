namespace WebStoreAPI.Queries
{
    public interface IGetAll<out T>
    {
        T Execute();
    }
}
