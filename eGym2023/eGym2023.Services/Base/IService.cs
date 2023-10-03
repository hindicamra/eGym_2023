using eGym2023.Model;

namespace eGym2023.Services.Base
{
    public interface IService<T, TSearch> where TSearch : class
    {
        Task<PagedResult<T>> Get(TSearch search = null);
        Task<T> GetById(int id);
    }
}
