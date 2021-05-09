using System.Threading.Tasks;
using GlueHome.Domain.UserServices;
using GlueHome.Model.Users;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GlueHome.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {       
        private readonly IUserService _userService;
        private readonly ILogger<UserController> _logger;

        public UserController(IUserService userService, ILogger<UserController> logger)
        {
            _userService = userService;
            _logger = logger;
        }

        // POST: api/Delivery
        [HttpPost]
        public async Task<ActionResult> Login([FromBody] SignIn login)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError($"bad request {login.EmailAddress}");
                return BadRequest();
            }

            _logger.LogInformation($"Logged in for {login.EmailAddress}");

            var user = await _userService.GetUser(login.EmailAddress, login.Password);

            return Ok(user);
        }
    }
}
