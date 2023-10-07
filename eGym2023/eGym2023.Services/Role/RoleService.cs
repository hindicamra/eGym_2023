using AutoMapper;
using eGym2023.Model.Models;
using eGym2023.Model.SearchObjects;
using eGym2023.Services.Base;
using eGym2023.Services.DataDB;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

namespace eGym2023.Services.Role
{
    public class RoleService :
         BaseService<RoleModel, DataDB.Role, RoleSearchObject>,
         IRoleService
    {
        public RoleService(EGymDbContext context, IMapper mapper) : base(context, mapper)
        { }
    }
}
