namespace eGym2023.Model.Models
{
    public class UserRole
    {
        public int UserRoleId { get; set; }

        public int? UserRolesUserId { get; set; }

        public int? UserRolesUserIdroleId { get; set; }

        public virtual RoleModel? UserRolesUserIdrole { get; set; }
    }
}
