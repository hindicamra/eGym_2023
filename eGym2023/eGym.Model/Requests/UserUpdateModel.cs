namespace eGym2023.Model.Requests
{
    public class UserUpdateModel
    {
        public string? Username { get; set; }

        public string? Name { get; set; }

        public string? Email { get; set; }

        public string? Phone { get; set; }

        public string? Address { get; set; }

        public int? RoleId { get; set; }
    }
}
