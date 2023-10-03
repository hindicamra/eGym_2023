namespace eGym2023.Model.Requests
{
    public class UserInsertModel
    {
        public string Username { get; set; } = null!;

        public string? Name { get; set; }

        public string? Email { get; set; }

        public string? Phone { get; set; }

        public string? Address { get; set; }

        public string? Password { get; set; }

        public int? RoleId { get; set; }
    }
}
