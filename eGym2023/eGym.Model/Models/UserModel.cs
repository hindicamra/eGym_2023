namespace eGym2023.Model.Models
{
    public class UserModel
    {
        public int UserId { get; set; }

        public string Username { get; set; } = null!;

        public string? Name { get; set; }

        public string? Email { get; set; }

        public string? Phone { get; set; }

        public string? Address { get; set; }

        public virtual ICollection<UserRole> Role { get; } = new List<UserRole>();   
    }
}
