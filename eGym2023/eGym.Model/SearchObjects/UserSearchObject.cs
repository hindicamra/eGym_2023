namespace eGym2023.Model.SearchObjects
{
    public class UserSearchObject : BaseSearchObject
    {
        public string? Username { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
        public int? RoleId { get; set; }
        public bool? IsRoleIncluded { get; set; }
    }
}
