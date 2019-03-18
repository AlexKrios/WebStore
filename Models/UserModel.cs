namespace WebStoreAPI.Models
{
    //Processing command request for user
    public class UserModel
    {
        public void Post(WebStoreContext db, User user)
        {
            db.Users.Add(user);
            db.SaveChanges();
        }
        public void Put(WebStoreContext db, User user)
        {
            db.Update(user);
            db.SaveChanges();
        }
        public void Delete(WebStoreContext db, User user)
        {
            db.Users.Remove(user);
            db.SaveChanges();
        }
    }
}

