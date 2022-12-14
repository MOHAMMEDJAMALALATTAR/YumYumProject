using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Yumyum.Data;
using Yumyum.Infrastructure.Services.Users;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Yumyum.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly YumyumDbContext _context;
        private readonly IUserService _userService;
        private readonly ILogger<UserController> _logger;

        public UserController (IUserService userService, YumyumDbContext context)
        {
            _userService = userService;
            _context = context;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var user = await _userService.Get(id);
            return Ok(user);
        }

        [HttpGet]
        public async Task<IActionResult> GetByUserName(string username)
        {
            var user = await _userService.GetUserByUsername(username);
            return Ok(user);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            var user = await _userService.DeleteUser(id);
            return Ok("User Deleted");
        }
    }
}
