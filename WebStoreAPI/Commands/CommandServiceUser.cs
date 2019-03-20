using WebStoreAPI.Models;

namespace WebStoreAPI.Commands
{
    //Processing command request for user
    public class CommandServiceUser : ICommandService<User>
    {
        private readonly WebStoreContext _db;
        public CommandServiceUser(WebStoreContext db)
        {
            _db = db;
        }
        public void Post(User user)
        {
            _db.Users.Add(user);
        }
        public void Put(User product)
        {
            _db.Update(product);
        }
        public void Delete(User user)
        {
            _db.Users.Remove(user);
        }
        public void SaveDb()
        {
            _db.SaveChanges();
        }
    }
}
