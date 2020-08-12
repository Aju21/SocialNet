using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SocialNet.API.Data;
using SocialNet.API.Dto;
using SocialNet.API.Models;

namespace SocialNet.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _repo;
        public AuthController(IAuthRepository repo)
        {
            _repo = repo;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserForRegisterDto usertoregister)
        {
            usertoregister.username = usertoregister.username.ToLower();

            if (await _repo.UserExists(usertoregister.username))
            {
                return BadRequest("Username already exists !");
            }

            var usertocreate = new User{
                Username = usertoregister.username
            };

            var createdUser = await _repo.Register(usertocreate,usertoregister.password);

            return StatusCode(201);
        }
    }
}