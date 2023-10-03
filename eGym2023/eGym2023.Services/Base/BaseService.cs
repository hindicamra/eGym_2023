using AutoMapper;
using eGym2023.Model;
using eGym2023.Model.SearchObjects;
using eGym2023.Services.DataDB;
using Microsoft.EntityFrameworkCore;

namespace eGym2023.Services.Base
{
    public class BaseService<T, TDb, TSearch> : IService<T, TSearch> where TDb : class where T : class where TSearch : BaseSearchObject
    {
        protected EGymDbContext _context;
        protected IMapper _mapper { get; set; }
        public BaseService(EGymDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public virtual async Task<List<T>> Get(TSearch? search = null)
        {
            var entity = _context.Set<TDb>().AsQueryable();
            entity = AddFilter(entity, search);
            if (search?.Page.HasValue == true && search?.PageSize.HasValue == true)
            {
                entity = entity.Take(search.PageSize.Value).Skip(search.Page.Value);
            }
            var list = entity.ToList();

            return Mapper.Map<IEnumerable<List<T>>>(list);
        }


        public virtual IQueryable<TDb> AddInclude(IQueryable<TDb> query, TSearch? search = null)
        {
            return query;
        }

        public virtual IQueryable<TDb> AddFilter(IQueryable<TDb> query, TSearch? search = null)
        {
            return query;
        }

        public virtual async Task<T> GetById(int id)
        {
            var entity = await _context.Set<TDb>().FindAsync(id);

            return _mapper.Map<T>(entity);
        }
    }
}