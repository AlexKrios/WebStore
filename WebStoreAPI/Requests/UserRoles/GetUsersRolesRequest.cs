namespace WebStoreAPI.Requests.UserRoles
{
    public class GetUsersRolesRequest
    {
        public int? UserId { get; set; }
        public int? RoleId { get; set; }
        public int? Skip { get; set; }
        public int? Take { get; set; }
    }
}
