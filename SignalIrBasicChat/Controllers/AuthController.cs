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

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] UserCreateDto Userdto)
        {
            await this.mUserService.CreateUser(Userdto.Username, Userdto.Password, Userdto.Email);
            return Ok("User Created");
        }

        [HttpGet("all")]
        public async Task<List<User>> GetAllUsers()
        {
            return await mUserService.GetAllUsers();
        }

        [HttpGet]
        public async Task<List<User>> GetVerifiedUsers()
        {
            return await mUserService.GetVerifiedUsers();
        }

        [HttpDelete("{nUserId}")]
        public async Task<IActionResult> DeleteUserById(int nUserId)
        {
            await this.mUserService.DeleteUserById(nUserId);
            return Ok();
        }
    }
}
