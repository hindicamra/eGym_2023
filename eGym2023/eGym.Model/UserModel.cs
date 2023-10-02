namespace eGym2023.Model
{
    public class UserModel
    {
        public int UserId { get; set; }

        public string Username { get; set; } = null!;

        public string? Name { get; set; }

        public string? Email { get; set; }

        public string? Phone { get; set; }

        public string? Address { get; set; }

        public int? RoleId { get; set; }
    }
}
