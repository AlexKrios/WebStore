namespace WebStoreAPI.Requests.Users
{
    public class GetUsersRequest
    {
        public string Name { get; set; }
        public int? MinAge { get; set; }
        public int? MaxAge { get; set; }
        public string Email { get; set; }
        public int? CityId { get; set; }
        public int? Skip { get; set; }
        public int? Take { get; set; }
    }
}
