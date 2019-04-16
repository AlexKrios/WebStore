namespace WebStoreAPI.Requests.UserRoles
{
    public class GetUserRolesRequest
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int RoleId { get; set; }
    }
}
