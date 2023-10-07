using eGym2023.Controllers.Base;
using eGym2023.Model.Models;
using eGym2023.Model.SearchObjects;
using eGym2023.Services.Role;
using Microsoft.AspNetCore.Mvc;

namespace eGym2023.Controllers
{
    [ApiController]
    public class RoleController : BaseController<RoleModel, RoleSearchObject>
    {
        public RoleController(ILogger<BaseController<RoleModel, RoleSearchObject>> logger, IRoleService service) : base(logger, service)
        {
        }
    }
}