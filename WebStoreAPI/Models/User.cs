namespace WebStoreAPI.Models
{
    //Model for object user
    public class User : IBaseEntity
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Role { get; set; }
        public int Age { get; set; }
    }
}
