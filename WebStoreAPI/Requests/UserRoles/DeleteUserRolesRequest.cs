namespace WebStoreAPI.Requests.UserRoles
{
    public class DeleteUserRolesRequest
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int RoleId { get; set; }
    }
}
