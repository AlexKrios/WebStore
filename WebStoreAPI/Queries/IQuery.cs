namespace WebStoreAPI.Queries
{
    public interface IQuery<out T>
    {
        T Execute();
        T Execute(int id);
        T Execute(string type);
    }
}
