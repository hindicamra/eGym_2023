using AutoMapper;
using eGym2023.Model.Models;
using eGym2023.Model.Requests;

namespace eGym2023.Services
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //User mapping
            CreateMap<DataDB.User, UserModel>();
            CreateMap<UserInsertModel, DataDB.User>();
            CreateMap<UserUpdateModel, DataDB.User>();

            //UserRole mapping
            CreateMap<DataDB.UserRole, UserRole>();
            //Role mapping
            CreateMap<DataDB.Role, RoleModel>();    
        }
    }
}
