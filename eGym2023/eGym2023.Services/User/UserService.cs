using AutoMapper;
using eGym2023.Model.Models;
using eGym2023.Model.SearchObjects;
using eGym2023.Services.Base;
using eGym2023.Services.DataDB;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

namespace eGym2023.Services.User
{
    public class UserService :
        BaseService<UserModel, DataDB.User, UserSearchObject>,
        IUserService
    {
        public UserService(EGymDbContext context, IMapper mapper) : base(context, mapper)
        { }

        public override IQueryable<DataDB.User> AddFilter(IQueryable<DataDB.User> query, UserSearchObject? search = null)
        {
            if (!string.IsNullOrEmpty(search?.Username))
            {
                query = query.Where(x => x.Username.StartsWith(search.Username));
            }
            if (!string.IsNullOrEmpty(search?.Name))
            {
                query = query.Where(x => x.Username.StartsWith(search.Name));
            }
            if (!string.IsNullOrEmpty(search?.Email))
            {
                query = query.Where(x => x.Username.StartsWith(search.Email));
            }
            if (!string.IsNullOrEmpty(search?.Address))
            {
                query = query.Where(x => x.Address.StartsWith(search.Address));
            }
            if (!string.IsNullOrEmpty(search?.Phone))
            {
                query = query.Where(x => x.Address.StartsWith(search.Phone));
            }
            if (search.RoleId != null)
            {
                //query = query.Where(x => x.RoleId == search.RoleId);
            }
            return base.AddFilter(query, search);
        }

        public override IQueryable<DataDB.User> AddInclude(IQueryable<DataDB.User> query, UserSearchObject? search = null)
        {
            if (search?.IsRoleIncluded == true)
            {
                query = query.Include("UserRoles.UserRolesUserIdrole");
            }
            return base.AddInclude(query, search);
        }

        public static string GenerateSalt()
        {
            RNGCryptoServiceProvider provider = new RNGCryptoServiceProvider();
            var byteArray = new byte[16];
            provider.GetBytes(byteArray);


            return Convert.ToBase64String(byteArray);
        }
        public static string GenerateHash(string salt, string password)
        {
            byte[] src = Convert.FromBase64String(salt);
            byte[] bytes = Encoding.Unicode.GetBytes(password);
            byte[] dst = new byte[src.Length + bytes.Length];

            System.Buffer.BlockCopy(src, 0, dst, 0, src.Length);
            System.Buffer.BlockCopy(bytes, 0, dst, src.Length, bytes.Length);

            HashAlgorithm algorithm = HashAlgorithm.Create("SHA1");
            byte[] inArray = algorithm.ComputeHash(dst);
            return Convert.ToBase64String(inArray);
        }
    }
}
