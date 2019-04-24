namespace APIModels.Requests.UserRoles
{
    public class UpdateUserRolesRequest
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int RoleId { get; set; }
    }
}
