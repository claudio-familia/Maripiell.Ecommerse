using Maripiell.Services.AuthAPI.Domain.Common;
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
        public async Task<IActionResult> Login(LoginUser user)
        {
            return Ok(await authService.Login(user));
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(UserDto user)
        {
            var response = await authService.Register(user);

            return Ok(response);
        }
    }
}
