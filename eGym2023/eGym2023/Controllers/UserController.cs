using eGym2023.Services;
using Microsoft.AspNetCore.Mvc;

namespace eGym2023.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService) => _userService = userService;


        [HttpGet]
        [Route("users")]
        public async Task<IActionResult> Index(int userId)
        {
            var user = await _userService.GetUserAsync(userId);
            return View(user);
        }
    }
}
