using Maripiell.Services.AuthAPI.Domain.Dto;
using Maripiell.Services.AuthAPI.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Maripiell.Services.AuthAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService authService;

        public AuthController(IAuthService authService)
        {
            this.authService = authService;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login()
        {
            return Ok();
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(UserDto user)
        {
            var response = await authService.Register(user);

            return Ok(response);
        }
    }
}
