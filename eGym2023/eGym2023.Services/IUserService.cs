using eGym2023.Model;

namespace eGym2023.Services
{
    public interface IUserService
    {
        Task<UserModel> GetUserAsync(int userId);
    }
}
