using Maripiell.Services.AuthAPI.Domain.Dto;

namespace Maripiell.Services.AuthAPI.Domain.Common
{
    public class LoginResponse(LoginDto user, string token)
    {
        public LoginDto? User { get; set; } = user;
        public string Token { get; set; } = token;
    }
}
