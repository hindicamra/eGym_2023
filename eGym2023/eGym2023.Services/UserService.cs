using eGym2023.Model;

namespace eGym2023.Services
{
    public class UserService : IUserService
    {
        public Task<UserModel> GetUserAsync(int userId)
        {
            return Task.FromResult(new UserModel
            {
                UserId = userId,
                Username = "username",
                Name = "name",
                Email = "email",
                Phone = "phone",
                Address = "address",
                RoleId = 1
            });
        }
    }
}
