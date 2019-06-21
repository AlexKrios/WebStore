namespace WebStoreAPI.Requests.Roles
{
    public class GetRolesRequest
    {
        public string Name { get; set; }
        public int? Skip { get; set; }
        public int? Take { get; set; }
    }
}
