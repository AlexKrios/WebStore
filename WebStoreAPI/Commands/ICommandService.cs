namespace WebStoreAPI.Commands
{
    public interface ICommandService<in T>
    {
        void Post(T product);
        void Put(T product);
        void Delete(T product);
        void SaveDb();
    }
}
