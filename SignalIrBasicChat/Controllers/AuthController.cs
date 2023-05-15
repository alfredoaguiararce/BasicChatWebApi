using Microsoft.AspNetCore.Mvc;
using SignalIrBasicChat.Models;
using SignalIrBasicChat.Services;

namespace SignalIrBasicChat.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController: ControllerBase
    {
        private readonly IUsers mUserService;

        public AuthController(IUsers mUserService)
        {
            this.mUserService = mUserService;
        }

        [HttpGet]
        public async Task<List<User>> GetUsers()
        {
            return await mUserService.GetVerifiedUsers();
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] UserCreateDto Userdto)
        {
            await this.mUserService.CreateUser(Userdto.Username, Userdto.Password, Userdto.Email);
            return Ok("User Created");
        }
    }
}
