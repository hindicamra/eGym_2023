using eGym2023.Controllers.Base;
using eGym2023.Model.Models;
using eGym2023.Model.SearchObjects;
using eGym2023.Services.User;
using Microsoft.AspNetCore.Mvc;

namespace eGym2023.Controllers
{
    [ApiController]
    public class UserController : BaseController<UserModel, UserSearchObject>
    {
        public UserController(ILogger<BaseController<UserModel,UserSearchObject>> logger, IUserService service) : base(logger, service)
        {
        }
    }
}