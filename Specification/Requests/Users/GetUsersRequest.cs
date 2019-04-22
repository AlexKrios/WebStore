namespace Specification.Requests.Users
{
    public class GetUsersRequest
    {
        public string Name { get; set; }
        public int? MinAge { get; set; }
        public int? MaxAge { get; set; }
        public string Email { get; set; }
        public int? CityId { get; set; }
    }
}
